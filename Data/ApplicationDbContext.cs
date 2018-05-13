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
                new Service() { Category = "Pharmacy" },
                new Service() { Category = "Counselling"}
            };
            foreach (Service s in _serviceList)
            {
                _context.Service.Add(s);
            }

                List<MedicalProfessional> _medicalProfessionaList = new List<MedicalProfessional>
        {
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Alexandra",
                LastName = "Killian",
                PhoneNumber = "(08) 8703 3021",
                Email = "AlexandraKillian@mindframepsychology.com.au",
                Notes = "Great Psychologist",
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
                    FacilityName = "MindFrame Psychology", Email = "hello@mindframepsychology.com.au", PhoneNo = "04202020", Website="https://www.mindframepsychology.com.au/", notes="Generalist counselling",
                    Location = new Address() {
                            PostCode = "2000", State="NSW", StreetNo="Suite 916, Level 9, St James Trust Building, 185 ", Street="Elizabeth", Suburb="Sydney"
                    }
                }
            }, //Put comma and paste from 'new MedicalProfessional() section'
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Aaron",
                LastName = "Becher",
                PhoneNumber = "(07) 4082 0135",
                Email = "AaronBecher@kildaremedical.com.au",
                Notes = "Works at Pharmacy",
                Service = _serviceList[2],
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
                    FacilityName = "Rushtons Pharmacy", Email = "rushtonspharmacy@kildaremedical.com.au", PhoneNo = "02 8822 3040", Website="http://kildaremedical.com.au", notes="Community Pharmacy",
                    Location = new Address() {
                            PostCode = "2148", State="NSW", StreetNo="36", Street="Kildare", Suburb="Blacktown"
                    }
                }
            },
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Aidan",
                LastName = "Colechin",
                PhoneNumber = "(03) 6253 7129",
                Email = "AidanColechin@rainbowmedical.com.au",
                Notes = "General Practitioner",
                Service = _serviceList[0], //0 is for general practitioner
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
                    FacilityName = "Rainbow Medical Practice", Email = "admin@rainbowmedical.com.au", PhoneNo = "121321312", Website="http://rainbowmedical.com.au", notes="Rainbow Practice Facility",
                    Location = new Address() {
                            PostCode = "2767", State="NSW", StreetNo="Shop 6", Street="60 Rosenthal STREET", Suburb="DOONSIDE"
                    }
                }
            },
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Tyler",
                LastName = "Stoneman",
                PhoneNumber = "(02) 6191 8932",
                Email = "TylerStoneman@activemedical.com.au",
                Notes = "General Practitioner",
                Service = _serviceList[0],
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
                    FacilityName = "Active Family Medical Centre", Email = "sydney@activemedical.com.au", PhoneNo = "04202020", Website="http://activemedical.com.au", notes="Active Medical Facility :)",
                    Location = new Address() {
                            PostCode = "2767", State="NSW", StreetNo="253 ", Street="Doonside CRESCENT ", Suburb="Doonside"
                    }
                }
            },
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Brock",
                LastName = "Sharland",
                PhoneNumber = "(03) 5338 2186",
                Email = "BrockSharland@mlcmedical.com.au",
                Notes = "professional notes",
                Service = _serviceList[0],
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
                    FacilityName = "MLC Centre Medical", Email = "sydney@mlcmedical.com.au", PhoneNo = "04202020", Website="http://mlcmedical.com.au", notes="The MLC Medical",
                    Location = new Address() {
                            PostCode = "2000", State="NSW", StreetNo="Suite 1003, MLC Centre, 19", Street="Martin PLACE", Suburb="Sydney"
                    }
                }
            },
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Alexander",
                LastName = "Leak",
                PhoneNumber = "(07) 4519 3112",
                Email = "AlexanderLeak@bridgedental.com.au",
                Notes = "Experienced Dentist",
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
                    FacilityName = "Bridge Street Dental", Email = "admin@bridgedental.com.au", PhoneNo = "04202020", Website="http://bridgedental.com.au", notes="Get your teeth fixed",
                    Location = new Address() {
                            PostCode = "2000", State="NSW", StreetNo="Unit 102, 4", Street="Bridge", Suburb="Sydney"
                    }
                }
            },
            new MedicalProfessional()
            { //This object is mostly complete now with all the variables u can put in it.
                FirstMidName = "Oscar",
                LastName = "Colebatch",
                PhoneNumber = "(02) 4934 4124",
                Email = "OscarColebatch@dentalspecialist.com.au",
                Notes = "Dentist",
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
                    FacilityName = "The Dental Specialist", Email = "admin@dentalspecialist.com.au", PhoneNo = "04202020", Website="http://dentalspecialist.com.au", notes="Best Dentist in Town",
                    Location = new Address() {
                            PostCode = "2000", State="NSW", StreetNo="Level 11, 33", Street="York", Suburb="Sydney"
                    }
                }
            }
        };
            _context.AddRange(_medicalProfessionaList);
            await _context.SaveChangesAsync();
        }
    }
 

}