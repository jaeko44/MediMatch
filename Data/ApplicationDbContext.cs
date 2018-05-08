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
            
            List<Service> _serviceList = new List<Service> {
                new Service() { Category = "General Practitioner" },
                new Service() { Category = "Dentist" },
                new Service() { Category = "Pharmacy" }
            };
            foreach (Service s in _serviceList)
            {
                _context.Service.Add(s);
            }

                List<MedicalProfessional> _medicalProfessionaList = new List<MedicalProfessional>
        {
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "First",
                LastName = "Practitioner",
                PhoneNumber = "0402020",
                Email = "professional@clinic.edu.au",
                Notes = "professional notes",
                Service = _serviceList[1],
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
                
                Facility = new Facility() {
                    FacilityName = "Sydney Clinic", Email = "sydney@rmit.edu.au", PhoneNo = "04202020", Website="http://rmit.edu.au", notes="Great Facility",
                    Location = new Address() {
                            PostCode = "2000", State="NSW", StreetNo="5", Street="York", Suburb="Sydney"
                    }
                }
            }, //Put comma and paste from 'new MedicalProfessional() section'
            new MedicalProfessional()
            {
                FirstMidName = "Practitioner",
                LastName = "Secondary",
                PhoneNumber = "0402020222",
                Email = "professional2@clinic.edu.au",
                Notes = "What kind of doctor am I?",
                Service = _serviceList[0],
                Facility = new Facility() {
                    FacilityName = "Melbourne Clinic", Email = "melbourne@rmit.edu.au", PhoneNo = "04202020", Website="http://rmit.edu.au", notes="Great Facility",
                    Location = new Address() {
                            PostCode = "3000", State="Victoria", StreetNo="20", Street="Newtown", Suburb="Melbourne"
                    }
                }
            }
        };
            _context.AddRange(_medicalProfessionaList);
            await _context.SaveChangesAsync();
        }
    }
 

}