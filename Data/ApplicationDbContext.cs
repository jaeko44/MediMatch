using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MediMatchRMIT.Models;
using Microsoft.Extensions.DependencyInjection;
using MediMatchRMIT.Data;
using Microsoft.EntityFrameworkCore.Design;

namespace MediMatchRMIT.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MediMatchRMIT.Models.MedicalProfessional> MedicalProfessional { get; set; }

        public DbSet<MediMatchRMIT.Models.Facility> Facility { get; set; }

        public DbSet<MediMatchRMIT.Models.Address> Address { get; set; }

        public DbSet<MediMatchRMIT.Models.Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=medimatch.db");
        }
    }

}
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseSqlite("Data Source=medimatch.db");
        return new ApplicationDbContext(builder.Options);
    }
}

public class SeedData
{
    private ApplicationDbContext _context;

    public SeedData(ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task Seed()
    {
        if (!_context.MedicalProfessional.Any())
        {
            _context.AddRange(_medicalProfessionaList);
            await _context.SaveChangesAsync();
        }
    }

    List<MedicalProfessional> _medicalProfessionaList = new List<MedicalProfessional>
        {
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Hello",
                LastName = "hello",
                PhoneNumber = "0402020",
                Email = "professional@clinic.edu.au",
                Notes = "professional notes",
                HoursActive = new List<HoursActive> {
                    //We can add a list of every week day they are active and their hours.
                    new HoursActive() {
                        WeekDays = "Sunday",
                        Hours = "9 AM - 5 PM"
                    },
                    new HoursActive() {
                        WeekDays = "Monday",
                        Hours = "9 AM - 6 PM"
                    } 
                },
                Service = new Service() { Category = "General Practitioner" },
                Facility = new Facility() {
                    FacilityName = "Clinic", Email = "clinic@rmit.edu.au", PhoneNo = "04202020", Website="http://rmit.edu.au", notes="Great Facility",
                    Location = new Address() {
                            PostCode = "2767", State="NSW", StreetNo="20", Street="Newbie Town", Suburb="New Jersey"
                    }
                }
            }, //Put comma and paste from 'new MedicalProfessional() section'
            new MedicalProfessional()
            {
                FirstMidName = "Hello",
                LastName = "hello",
                Service = new Service() { Category = "General Practitioner" },
                Facility = new Facility() {
                    FacilityName = "Clinic", Email = "clinic@rmit.edu.au", PhoneNo = "04202020", Website="http://rmit.edu.au", notes="Great Facility",
                    Location = new Address() {
                            PostCode = "2767", State="NSW", StreetNo="20", Street="Newbie Town", Suburb="New Jersey"
                    }
                }
            }
        };
}