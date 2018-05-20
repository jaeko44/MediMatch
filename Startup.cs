using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediMatchRMIT.Data;
using MediMatchRMIT.Models;
using MediMatchRMIT.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using MediMatchRMIT.Controllers;
using Microsoft.AspNetCore.Http;
using MediMatchRMIT.Classes;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MediMatchRMIT.Middleware;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using MediMatchRMIT.Controllers;

namespace MediMatchRMIT
{
    public partial class  Startup
    {
        public IConfiguration Configuration { get; }

        private SymmetricSecurityKey _signingKey;
        private TokenValidationParameters _tokenValidationParameters;
        private TokenProviderOptions _tokenProviderOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _signingKey =
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

            _tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };


            _tokenProviderOptions = new TokenProviderOptions
            {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256),
            };
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=medimatch-v1.2.db"));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<SeedData>();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                //options.Conventions.AuthorizeFolder("/Account/Manage");
                //options.Conventions.AuthorizePage("/Account/Logout");
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.AccessDeniedPath = "/Account/Forbidden/";
                //options.LoginPath = "/Account/LogIn";
                //options.LogoutPath = "/Account/Logout";
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = _tokenValidationParameters;
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";

                       return c.Response.WriteAsync("An error occurred processing your authentication.");
                   }
                };
            });
            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            services.AddSingleton<IEmailSender, EmailSender>();
            //Add Swagger UI for API Docs Generation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "MediMatch RMIT API",
                    Description = "ASP.net WEB-API Endpoint for Medimatch",
                    TermsOfService = "None",
                Contact = new Contact
                    {
                        Name = "Jonathan Philipos",
                        Email = "jonathan@det.io",
                        Url = "https://github.com/jaeko44"
                    },
                    License = new License
                    {
                        Name = "Use under Apache License Version 2.0",
                        Url = "http://www.apache.org/licenses/"
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedData dbSeed, ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseJWTTokenProviderMiddleware(Options.Create(_tokenProviderOptions));
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediMatch RMIT API V1");
                c.RoutePrefix = "docs";
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=App}/{id?}");
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "App" });
            });
            try
            {
                context.Database.Migrate();
                dbSeed.Seed().Wait();
                var adminUser = new ApplicationUser
                {

                    UserName = Configuration["AppSettings:Email"],
                    Email = Configuration["AppSettings:Email"],
                };
                string adminPassword = Configuration.GetSection("AppSettings:Password").Value;
                CreateRoles(serviceProvider, adminUser, adminPassword).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while seeding the database");
                Console.Write(ex);
            }

        }

        public async Task CreateRoles(IServiceProvider serviceProvider, ApplicationUser adminUser, string adminPassword)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Moderators", "Patient", "MedicalProfessional" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var _user = await UserManager.FindByEmailAsync(adminUser.Email);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(adminUser, adminPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            else
            {
                await UserManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

    }
}
