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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MediMatchRMIT.Models.MedicalProfessional> MedicalProfessional
        {
            get;
            set;
        }
        //did u add the () orry
        public DbSet<MediMatchRMIT.Models.Facility> Facility
        {
            get;
            set;
        }

        public DbSet<MediMatchRMIT.Models.Address> Address
        {
            get;
            set;
        }

        public DbSet<MediMatchRMIT.Models.Service> Service
        {
            get;
            set;
        }

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
                new Service() {
                Category = "General Practitioner"
                },
                new Service() {
                Category = "Dentist"
                },
                new Service() {
                Category = "Pharmacy"
                },
                new Service() {
                Category = "Physiotherapist"
                },
                new Service() {
                Category = "Psychologist"
                }
             };
            foreach (Service s in _serviceList)
            {
                _context.Service.Add(s);
            }
            List<Facility> _facilityList = new List<Facility> {
                new Facility() {
                FacilityName = "Albert Street Sports & Spinal Injury Centre",
                  Location = new Address() {
                  StreetNo = "32",
                    Street = "Albert STREET",
                    Suburb = "WARRAGUL",
                    State = "Vic",
                    PostCode = "3820"
                  }
                },
                new Facility() {
                FacilityName = "Antenatal & Postnatal Psychology Network - North Carlton",
                  Location = new Address() {
                  StreetNo = "806",
                    Street = "Lygon STREET",
                    Suburb = "CARLTON NORTH",
                    State = "Vic",
                    PostCode = "3054"
                  }
                },
                new Facility() {
                FacilityName = "Melbourne Clinic",
                  Email = "melbourne@rmit.edu.au",
                  PhoneNo = "04202020",
                  Website = "http://rmit.edu.au",
                  notes = "Great Facility",
                  Location = new Address() {
                  PostCode = "3000",
                    State = "Victoria",
                    StreetNo = "20",
                    Street = "Newtown",
                    Suburb = "Melbourne"
                  }
                }
             };
            foreach (Facility f in _facilityList)
            {
                _context.Facility.Add(f);
            }
            List<MedicalProfessional> _medicalProfessionaList = new List<MedicalProfessional> {
    new MedicalProfessional() {
     FirstMidName = "Ebony Beth",
      LastName = "Axford",
      Service = _serviceList[3],
      Facility = _facilityList[0],
      PhoneNumber = "03 5622 1111",
      Email = "admin@albertstreetsports.physio",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 5:30pm"
       }
      }
    },
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
    },
    new MedicalProfessional() {
     FirstMidName = "Sarah Jane",
      LastName = "Axford",
      Service = _serviceList[4],
      Facility = _facilityList[1],
      PhoneNumber = "0413 662 916",
      Email = "emmasymes@epsychology.com"
    },
    new MedicalProfessional() {
     FirstMidName = "Practitioner",
      LastName = "Secondary",
      PhoneNumber = "0402020222",
      Email = "professional2@clinic.edu.au",
      Notes = "What kind of doctor am I?",
      Service = _serviceList[0],
      Facility = _facilityList[3]
    },
    new MedicalProfessional() {
     FirstMidName = "Chris",
      LastName = "Apostolopoulos",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "austin Health - Royal Talbot Rehabilitation Centre",
        Location = new Address() {
         StreetNo = "1",
          Street = "Yarra BOULEVARD",
          Suburb = "KEW",
          State = "Vic",
          PostCode = "3101"
        }
      },
      PhoneNumber = "03 9490 7500",
      Email = "Royal.Talbot.austin.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ebony Beth",
      LastName = "Axford",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Albert Street Sports & Spinal Injury Centre",
        Location = new Address() {
         StreetNo = "32",
          Street = "Albert STREET",
          Suburb = "WARRAGUL", State = "Vic",
          PostCode = "3820"
        }
      },
      PhoneNumber = "03 5622 1111",
      Email = "admin@albertstreetsports.physio",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 5:30pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 5:30pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sarah Jane",
      LastName = "Axford",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Antenatal & Postnatal Psychology Network - North Carlton",
        Location = new Address() {
         StreetNo = "806",
          Street = "Lygon STREET",
          Suburb = "CARLTON NORTH", State = "Vic",
          PostCode = "3054"
        }
      },
      PhoneNumber = "0413 662 916",
      Email = "emmasymes@epsychology.com"
    },
    new MedicalProfessional() {
     FirstMidName = "Anne",
      LastName = "Africa",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Aqua Physio",
        Location = new Address() {
         StreetNo = "12",
          Street = "Maitland STREET",
          Suburb = "GEELONG WEST", State = "Vic",
          PostCode = "3218"
        }
      },
      PhoneNumber = "03 5221 0555",
      Email = "info@newtownphysio.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "2pm - 3pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "2pm - 3pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Chris",
      LastName = "Apostolopoulos",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Austin Health - Royal Talbot Rehabilitation Centre",
        Location = new Address() {
         StreetNo = "1",
          Street = "Yarra BOULEVARD",
          Suburb = "KEW", State = "Vic",
          PostCode = "3101"
        }
      },
      PhoneNumber = "03 9490 7500",
      Email = "Royal.Talbot.austin.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Conrad Wells Hamilton",
      LastName = "Aikin",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Australian College Of Psychologists In Clinical Private Practice - Brunswick",
        Location = new Address() {
         StreetNo = "2",
          Street = "Errol AVENUE",
          Suburb = "BRUNSWICK", State = "Vic",
          PostCode = "3056"
        }
      },
      PhoneNumber = "03 9380 6025",
      Email = "acpcpp@psychologistsvictoria.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Natasha Danielle",
      LastName = "Ascenzo",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Australian College Of Psychologists In Clinical Private Practice - Brunswick",
        Location = new Address() {
         StreetNo = "2",
          Street = "Errol AVENUE",
          Suburb = "BRUNSWICK", State = "Vic",
          PostCode = "3056"
        }
      },
      PhoneNumber = "03 9380 6025",
      Email = "acpcpp@psychologistsvictoria.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Steven",
      LastName = "Ajzenman",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Back In Motion - Mentone",
        Location = new Address() {
         StreetNo = "11",
          Street = "Como PARADE",
          Suburb = "MENTONE", State = "Vic",
          PostCode = "3194"
        }
      },
      PhoneNumber = "03 9872 4141",
      Email = "mentone@backinmotion.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Joanne Francene",
      LastName = "Airey",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Back In Motion Health Group - Blackburn",
        Location = new Address() {
         StreetNo = "Suite 3 130",
          Street = "South PARADE",
          Suburb = "BLACKBURN", State = "Vic",
          PostCode = "3130"
        }
      },
      PhoneNumber = "03 9878 1919",
      Email = "blackburn@backinmotion.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Douraid",
      LastName = "Abbas",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Ballarat Health Services - Base Hospital",
        Location = new Address() {
         StreetNo = "1",
          Street = "Drummond STREET",
          Suburb = "BALLARAT", State = "Vic",
          PostCode = "3350"
        }
      },
      PhoneNumber = "03 5320 4000",
      Email = "info@bhs.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "William Robert St John",
      LastName = "Ainslie",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Ballarat Health Services - Base Hospital",
        Location = new Address() {
         StreetNo = "1",
          Street = "Drummond STREET",
          Suburb = "BALLARAT", State = "Vic",
          PostCode = "3350"
        }
      },
      PhoneNumber = "03 5320 4000",
      Email = "info@bhs.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ayhan",
      LastName = "Ada",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Barwon Health - McKellar Centre",
        Location = new Address() {
         StreetNo = "45-95",
          Street = "Ballarat ROAD",
          Suburb = "NORTH GEELONG", State = "Vic",
          PostCode = "3215"
        }
      },
      PhoneNumber = "03 4215 5200",
      Email = "postmaster@barwonhealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
      FirstMidName = "Jordana",
      LastName = "Aamalia",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Bayside Medical Group - Hampton",
        Location = new Address() {
         StreetNo = "3",
          Street = "Service STREET",
          Suburb = "HAMPTON", State = "Vic",
          PostCode = "3188"
        }
      },
      PhoneNumber = "03 9598 9911",
      Email = "JordanaAamalia@BMG.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ariana",
      LastName = "Axarlis",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Beachbox Physiotherapy",
        Location = new Address() {
         StreetNo = "133",
          Street = "Nepean HIGHWAY",
          Suburb = "SEAFORD", State = "Vic",
          PostCode = "3198"
        }
      },
      Email = "ArianaAxarlis@BeachboxPhysiotherapy.com.au",
      PhoneNumber = "03 9036 7700",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Adeola Oluwatosin Kofoworola",
      LastName = "Akadiri",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Beleura Private Hospital",
        Location = new Address() {
         StreetNo = "925",
          Street = "Nepean HIGHWAY",
          Suburb = "MORNINGTON", State = "Vic",
          PostCode = "3931"
        }
      },
      PhoneNumber = "03 5976 0888",
      Email = "Adeola@BeleuraPrivateHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "6am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Natasha Jane",
      LastName = "Aylen",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Beleura Private Hospital",
        Location = new Address() {
         StreetNo = "925",
          Street = "Nepean HIGHWAY",
          Suburb = "MORNINGTON", State = "Vic",
          PostCode = "3931"
        }
      },
      PhoneNumber = "03 5976 0888",
      Email = "Natasha@BeleuraPrivateHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "6am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Shama",
      LastName = "Aradhye",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bellbird Private Hospital",
        Location = new Address() {
         StreetNo = "198",
          Street = "Canterbury ROAD",
          Suburb = "BLACKBURN", State = "Vic",
          PostCode = "3130"
        }
      },
      Email = "ShamaAradhye@BellbirdPrivateHospital.com.au", PhoneNumber = "03 9845 2333",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Poornima",
      LastName = "Amaranarayana",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bendigo Health - Bendigo Hospital",
        Location = new Address() {
         StreetNo = "100",
          Street = "Barnard STREET",
          Suburb = "BENDIGO", State = "Vic",
          PostCode = "3552"
        }
      },
      PhoneNumber = "03 5454 6000",
      Email = "Poornima@BendigoHealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Adel Seliem Sabry",
      LastName = "Asaid",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bendigo Health - Bendigo Hospital",
        Location = new Address() {
         StreetNo = "100",
          Street = "Barnard STREET",
          Suburb = "BENDIGO", State = "Vic",
          PostCode = "3552"
        }
      },
      PhoneNumber = "03 5454 6000",
      Email = "Adel@BendigoHealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Anju",
      LastName = "Agarwal",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bendigo Health - Bendigo Hospital",
        Location = new Address() {
         StreetNo = "100",
          Street = "Barnard STREET",
          Suburb = "BENDIGO", State = "Vic",
          PostCode = "3552"
        }
      },
      PhoneNumber = "03 5454 9184",
      Email = "ereferral@bendigohealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "11am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "11am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Anamalay",
      LastName = "Ayasamy",
      Service = _serviceList[1],
      Facility = new Facility() {
       FacilityName = "Beyond Smiles Dentistry",
        Location = new Address() {
         StreetNo = "Suite 3 572",
          Street = "Main STREET",
          Suburb = "MORDIALLOC", State = "Vic",
          PostCode = "3195"
        }
      },
      PhoneNumber = "03 9580 1100",
      Email = "admin@beyondsmiles.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sarpreet Kaur",
      LastName = "Anand",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Bodyline Health",
        Location = new Address() {
         StreetNo = "17",
          Street = "Main ROAD",
          Suburb = "LOWER PLENTY", State = "Vic",
          PostCode = "3093"
        }
      },
      PhoneNumber = "03 9017 4784",
      Email = "info@bodylinehealth.com",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Susan Maria",
      LastName = "Athaide",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Brighton Psychology Centre",
        Location = new Address() {
         StreetNo = "175",
          Street = "Bay STREET",
          Suburb = "BRIGHTON", State = "Vic",
          PostCode = "3186"
        }
      },
      PhoneNumber = "03 9596 8844",
      Email = "bpc@brightpsych.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Jawaria",
      LastName = "Avais",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Broadmeadows Health Service",
        Location = new Address() {
         StreetNo = "35",
          Street = "Johnstone STREET",
          Suburb = "BROADMEADOWS", State = "Vic",
          PostCode = "3047"
        }
      },
      Email = "JawariaAvais@BroadmeadowsHealthService.com.au",
      PhoneNumber = "03 8345 5000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Martin Rolf",
      LastName = "Axelsson",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Brooke Street Medical Centre",
        Location = new Address() {
         StreetNo = "14",
          Street = "Brooke STREET",
          Suburb = "WOODEND", State = "Vic",
          PostCode = "3442"
        }
      },
      PhoneNumber = "03 5427 1002",
      Email = "bsmc@bsmc.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 4pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 4pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 3:30pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 3:30pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Riccardo",
      LastName = "Abad",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Burnside Medical Centre",
        Location = new Address() {
         StreetNo = "Shop 19/25",
          Street = "Westwood DRIVE",
          Suburb = "BURNSIDE", State = "Vic",
          PostCode = "3023"
        }
      },
      PhoneNumber = "03 9363 6766",
      Email = "Riccardo@BurnsideMedicalCentre.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Manju",
      LastName = "Agarwal",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Cabrini Hospital - Brighton",
        Location = new Address() {
         StreetNo = "243",
          Street = "New STREET",
          Suburb = "BRIGHTON", State = "Vic",
          PostCode = "3186"
        }
      },
      PhoneNumber = "03 9508 8777",
      Email = "Manju@CabriniHospitalBrighton.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "7am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ahmad",
      LastName = "Aga",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Cabrini Hospital - Malvern",
        Location = new Address() {
         StreetNo = "183",
          Street = "Wattletree ROAD",
          Suburb = "MALVERN", State = "Vic",
          PostCode = "3144"
        }
      },
      PhoneNumber = "03 9508 1222",
      Email = "admin@cabrini.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Biola Morenike",
      LastName = "Araba",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Cabrini Hospital - Malvern",
        Location = new Address() {
         StreetNo = "183",
          Street = "Wattletree ROAD",
          Suburb = "MALVERN", State = "Vic",
          PostCode = "3144"
        }
      },
      PhoneNumber = "03 9508 1222",
      Email = "admin@cabrini.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Kerry",
      LastName = "Athanasiadis",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Camberwell Counselling",
        Location = new Address() {
         StreetNo = "Level 1 760",
          Street = "Riversdale ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      PhoneNumber = "0404 082 675",
      Email = "help@camberwellcounselling.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Trish",
      LastName = "Ayers",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Camberwell Counselling",
        Location = new Address() {
         StreetNo = "Level 1 760",
          Street = "Riversdale ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      PhoneNumber = "0404 082 675",
      Email = "help@camberwellcounselling.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Chanelle",
      LastName = "Adam",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Carol Schulz - Clinical and Counselling Psychologist",
        Location = new Address() {
         StreetNo = "176",
          Street = "Beach STREET",
          Suburb = "FRANKSTON", State = "Vic",
          PostCode = "3199"
        }
      },
      PhoneNumber = "03 9781 0600",
      Email = "carol.schulz.maps@gmail.com",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Amena",
      LastName = "Azizi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      Email = "AmenaAzizi@CaseyHospital.com.au",
      PhoneNumber = "03 8768 1200",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Indu Udayamali Amarakoon",
      LastName = "Mudiyanselage",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      PhoneNumber = "03 8768 1200",
      Email = "Indu@CaseyHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ali",
      LastName = "Asadpour",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      Email = "AliAsadpour@CaseyHospital.com.au",
      PhoneNumber = "03 8768 1200",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Allan Chung Yan",
      LastName = "Au",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      PhoneNumber = "03 8768 1200",
      Email = "Allan@CaseyHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Hesham",
      LastName = "Azer",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Churinga Medical Centre",
        Location = new Address() {
         StreetNo = "465",
          Street = "Mt Dandenong ROAD",
          Suburb = "KILSYTH", State = "Vic",
          PostCode = "3137"
        }
      },
      PhoneNumber = "03 9722 9888",
      Email = "Hesham@ChuringaMedicalCentre.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Marisa Gianna",
      LastName = "Abate",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Churinga Medical Centre",
        Location = new Address() {
         StreetNo = "465",
          Street = "Mt Dandenong ROAD",
          Suburb = "KILSYTH", State = "Vic",
          PostCode = "3137"
        }
      },
      PhoneNumber = "03 9722 9888",
      Email = "Marisa@ChuringaMedicalCentre.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Amali Indika",
      LastName = "Abayawardana",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Corazon Centre Inc.",
        Location = new Address() {
         StreetNo = "11",
          Street = "Mortimer STREET",
          Suburb = "WERRIBEE", State = "Vic",
          PostCode = "3030"
        }
      },
      PhoneNumber = "03 9974 2756",
      Email = "contact@corazon.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Lee",
      LastName = "Ajzenman",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Core Physio & Pilates",
        Location = new Address() {
         StreetNo = "Level 2 370",
          Street = "Glen Huntly ROAD",
          Suburb = "ELSTERNWICK", State = "Vic",
          PostCode = "3185"
        }
      },
      PhoneNumber = "03 9523 8111",
      Email = "info@coremelbourne.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "7am - 1pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Catherina",
      LastName = "Audish",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Craigieburn Health Service",
        Location = new Address() {
         StreetNo = "274-304",
          Street = "Craigieburn ROAD",
          Suburb = "CRAIGIEBURN", State = "Vic",
          PostCode = "3064"
        }
      },
      PhoneNumber = "03 8338 3030",
      Email = "corporatecommunication@nh.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Rani Sharina Kay",
      LastName = "Axtens",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Delmont Private Hospital",
        Location = new Address() {
         StreetNo = "298-306",
          Street = "Warrigal ROAD",
          Suburb = "GLEN IRIS", State = "Vic",
          PostCode = "3146"
        }
      },
      PhoneNumber = "03 9805 7333",
      Email = "delmont@delmonthospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Linda",
      LastName = "Aykut",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Donvale Rehabilitation Hospital",
        Location = new Address() {
         StreetNo = "1119",
          Street = "Doncaster ROAD",
          Suburb = "DONVALE", State = "Vic",
          PostCode = "3111"
        }
      },
      Email = "LindaAykut@DonvaleRehabilitationHospital.com.au",
      PhoneNumber = "03 9841 1400",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Mounir Said",
      LastName = "Ayache",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Dorset Rehabilitation Centre",
        Location = new Address() {
         StreetNo = "146",
          Street = "Derby STREET",
          Suburb = "PASCOE VALE", State = "Vic",
          PostCode = "3044"
        }
      },
      PhoneNumber = "03 8371 94778",
      Email = "Mounir@DorsetRehabilitationCentre.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Hussein Hadi Irhaif",
      LastName = "Alabodi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Eastern",
        Location = new Address() {
         StreetNo = "1",
          Street = "Arnold STREET",
          Suburb = "BOX HILL", State = "Vic",
          PostCode = "3128"
        }
      },
      PhoneNumber = "03 8807 7100",
      Email = "Hussein@EpworthEastern.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Vinna",
      LastName = "An",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Eastern",
        Location = new Address() {
         StreetNo = "1",
          Street = "Arnold STREET",
          Suburb = "BOX HILL", State = "Vic",
          PostCode = "3128"
        }
      },
      PhoneNumber = "03 8807 7100",
      Email = "Vinna@Epworth Eastern.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sudhanshu",
      LastName = "Agarwal",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Hawthorn",
        Location = new Address() {
         StreetNo = "50",
          Street = "Burwood ROAD",
          Suburb = "HAWTHORN", State = "Vic",
          PostCode = "3122"
        }
      },
      Email = "SudhanshuAgarwal@EpworthHawthorn.com.au",
      PhoneNumber = "03 9097 1400",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Rodney",
      LastName = "Aziz",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Hawthorn",
        Location = new Address() {
         StreetNo = "50",
          Street = "Burwood ROAD",
          Suburb = "HAWTHORN", State = "Vic",
          PostCode = "3122"
        }
      },
      Email = "RodneyAziz@EpworthHawthorn.com.au",
      PhoneNumber = "03 9097 1400",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Michelle Seok Kwan",
      LastName = "An",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Hawthorn",
        Location = new Address() {
         StreetNo = "50",
          Street = "Burwood ROAD",
          Suburb = "HAWTHORN", State = "Vic",
          PostCode = "3122"
        }
      },
      PhoneNumber = "03 9097 1400",
      Email = "Michelle@EpworthHawthorn.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Matthew William",
      LastName = "Acheson",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Rehabilitation Camberwell",
        Location = new Address() {
         StreetNo = "888",
          Street = "Toorak ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      PhoneNumber = "03 9809 2444",
      Email = "rehab@epworth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Nasser Jamil Al",
      LastName = "Hammad",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Rehabilitation Camberwell",
        Location = new Address() {
         StreetNo = "888",
          Street = "Toorak ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      PhoneNumber = "03 9809 2444",
      Email = "rehab@epworth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sanka Malindra Galappatti",
      LastName = "Amadoru",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Rehabilitation Camberwell",
        Location = new Address() {
         StreetNo = "888",
          Street = "Toorak ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      PhoneNumber = "03 9809 2444",
      Email = "rehab@epworth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Hamed",
      LastName = "Asadi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Rehabilitation Camberwell",
        Location = new Address() {
         StreetNo = "888",
          Street = "Toorak ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      Email = "HamedAsadi@EpworthRehabilitationCamberwell.com.au",
      PhoneNumber = "03 9809 2444",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Rose Michelle",
      LastName = "Acher",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Epworth Richmond",
        Location = new Address() {
         StreetNo = "89",
          Street = "Bridge ROAD",
          Suburb = "RICHMOND", State = "Vic",
          PostCode = "3121"
        }
      },
      PhoneNumber = "03 9426 6666",
      Email = "info@epworth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Idin Ahangar",
      LastName = "Nazari",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Essendon Private Hospital",
        Location = new Address() {
         StreetNo = "35",
          Street = "Rosehill ROAD",
          Suburb = "ESSENDON WEST", State = "Vic",
          PostCode = "3040"
        }
      },
      PhoneNumber = "03 9337 9577",
      Email = "eph_admissions@iphoa.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Mahiuddin Abdul",
      LastName = "Ahad",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Essendon Private Hospital",
        Location = new Address() {
         StreetNo = "35",
          Street = "Rosehill ROAD",
          Suburb = "ESSENDON WEST", State = "Vic",
          PostCode = "3040"
        }
      },
      PhoneNumber = "03 9337 9577",
      Email = "eph_admissions@iphoa.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Abdelrahim Hassan",
      LastName = "Azizi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Essendon Private Hospital",
        Location = new Address() {
         StreetNo = "35",
          Street = "Rosehill ROAD",
          Suburb = "ESSENDON WEST", State = "Vic",
          PostCode = "3040"
        }
      },
      PhoneNumber = "03 9337 9577",
      Email = "eph_admissions@iphoa.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Saqlain",
      LastName = "Abbas",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Fawkner Health Care",
        Location = new Address() {
         StreetNo = "1274",
          Street = "Sydney ROAD",
          Suburb = "FAWKNER", State = "Vic",
          PostCode = "3060"
        }
      },
      Email = "SaqlainAbbas@FawknerHealthCare.com.au",
      PhoneNumber = "03 9357 1199",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "10am - 2pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Bella Baldan",
      LastName = "Ajayoglu",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Footscray Hospital - Western Health",
        Location = new Address() {
         StreetNo = "148",
          Street = "Gordon STREET",
          Suburb = "FOOTSCRAY", State = "Vic",
          PostCode = "3011"
        }
      },
      PhoneNumber = "03 8345 6666",
      Email = "Bella@FootscrayHospitalWesternHealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Niranjan Janaka Singankutti",
      LastName = "Arachchi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Footscray Hospital - Western Health",
        Location = new Address() {
         StreetNo = "148",
          Street = "Gordon STREET",
          Suburb = "FOOTSCRAY", State = "Vic",
          PostCode = "3011"
        }
      },
      PhoneNumber = "03 8345 6666",
      Email = "Niranjan@FootscrayHospitalWesternHealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "William Robert",
      LastName = "Adam",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Goulburn Valley Health - Shepparton Campus",
        Location = new Address() {
         StreetNo = "2",
          Street = "Graham STREET",
          Suburb = "SHEPPARTON", State = "Vic",
          PostCode = "3630"
        }
      },
      PhoneNumber = "1800 222 582",
      Email = "ics.intake@gvhealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Mohamed Anwar",
      LastName = "Atalla",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Goulburn Valley Health - Shepparton Campus",
        Location = new Address() {
         StreetNo = "2",
          Street = "Graham STREET",
          Suburb = "SHEPPARTON", State = "Vic",
          PostCode = "3630"
        }
      },
      PhoneNumber = "1800 222 582",
      Email = "ics.intake@gvhealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Shiraz",
      LastName = "Akbar",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Goulburn Valley Health - Shepparton Campus",
        Location = new Address() {
         StreetNo = "2",
          Street = "Graham STREET",
          Suburb = "SHEPPARTON", State = "Vic",
          PostCode = "3630"
        }
      },
      PhoneNumber = "1800 222 582",
      Email = "ics.intake@gvhealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Rachel Louise",
      LastName = "Avery",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Greenview Psychology",
        Location = new Address() {
         StreetNo = "16",
          Street = "Flintoff STREET",
          Suburb = "GREENSBOROUGH", State = "Vic",
          PostCode = "3088"
        }
      },
      PhoneNumber = "0411 221 847",
      Email = "info@greenviewpsychology.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Claire Terese",
      LastName = "Ahern",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "HealthSure Medical Centre - Coburg",
        Location = new Address() {
         StreetNo = "1B",
          Street = "Louisa STREET",
          Suburb = "COBURG", State = "Vic",
          PostCode = "3058"
        }
      },
      PhoneNumber = "03 9386 6680",
      Email = "coburg@healthsuremc.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Aliye ",
      LastName = "Akarsu-Atakan",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "HealthSure Medical Centre - Coburg",
        Location = new Address() {
         StreetNo = "1B",
          Street = "Louisa STREET",
          Suburb = "COBURG", State = "Vic",
          PostCode = "3058"
        }
      },
      PhoneNumber = "03 9386 6680",
      Email = "coburg@healthsuremc.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Stephen Norman",
      LastName = "Ayles",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Healthy Minds Psychological Services - Airport West",
        Location = new Address() {
         StreetNo = "Suite 2 23",
          Street = "Louis STREET",
          Suburb = "AIRPORT WEST",
          State = "Vic",
          PostCode = "3042"
        }
      },
      PhoneNumber = "03 9366 7003",
      Email = "Info@healthyminds.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Stephen Norman",
      LastName = "Ayles",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Healthy Minds Psychological Services - Airport West",
        Location = new Address() {
         StreetNo = "Suite 2 23",
          Street = "Louis STREET",
          Suburb = "AIRPORT WEST",
          State = "Vic",
          PostCode = "3042"
        }
      },
      PhoneNumber = "03 9366 7003",
      Email = "Info@healthyminds.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Katrina Diane",
      LastName = "Aycardo",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Healthy Minds Psychological Services - Doncaster",
        Location = new Address() {
         StreetNo = "19",
          Street = "Village AVENUE",
          Suburb = "DONCASTER",
          State = "Vic",
          PostCode = "3108"
        }
      },
      PhoneNumber = "03 9366 7003",
      Email = "info@healthyminds.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Doha Al",
      LastName = "Maliki",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Hillcrest Health Centre",
        Location = new Address() {
         StreetNo = "50",
          Street = "Bamburgh STREET",
          Suburb = "JACANA",
          State = "Vic",
          PostCode = "3047"
        }
      },
      PhoneNumber = "03 9302 3005",
      Email = "manager@hillcresthealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "4pm - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Evelyn Ann",
      LastName = "Ahin",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Hoppers Physio",
        Location = new Address() {
         StreetNo = "171",
          Street = "Heaths ROAD",
          Suburb = "HOPPERS CROSSING",
          State = "Vic",
          PostCode = "3029"
        }
      },
      PhoneNumber = "03 9749 5110",
      Email = "info@hoppersphysio.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Mathew Brian Ah",
      LastName = "Chow",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Integrated Health Monash University (Clayton Campus)",
        Location = new Address() {
         StreetNo = "42",
          Street = "Scenic BOULEVARD",
          Suburb = "CLAYTON",
          State = "Vic",
          PostCode = "3168"
        }
      },
      PhoneNumber = "03 9562 9006",
      Email = "info@physio.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Simon Tareq",
      LastName = "Ata",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Ivanhoe Medical Clinic",
        Location = new Address() {
         StreetNo = "22",
          Street = "Livingstone STREET",
          Suburb = "IVANHOE",
          State = "Vic",
          PostCode = "3079"
        }
      },
      PhoneNumber = "03 9499 1245",
      Email = "Simon@IvanhoeMedicalClinic.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Tahera",
      LastName = "Adamjee",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Maroondah Hospital",
        Location = new Address() {
         StreetNo = "1-15",
          Street = "Davey DRIVE",
          Suburb = "RINGWOOD EAST",
          State = "Vic",
          PostCode = "3135"
        }
      },
      PhoneNumber = "03 9871 3333",
      Email = "maroondah.hospital@maroondah.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Alicia Wai Pheng",
      LastName = "Au",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Maroondah Hospital",
        Location = new Address() {
         StreetNo = "1-15",
          Street = "Davey DRIVE",
          Suburb = "RINGWOOD EAST",
          State = "Vic",
          PostCode = "3135"
        }
      },
      PhoneNumber = "03 9871 3333",
      Email = "maroondah.hospital@maroondah.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Reinier Nioko",
      LastName = "Apolonio",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Medical One - QV",
        Location = new Address() {
         StreetNo = "Level 3 / 23 QV Terrace - 292",
          Street = "Swanston STREET",
          Suburb = "MELBOURNE", State = "Vic",
          PostCode = "3000"
        }
      },
      PhoneNumber = "03 8663 7000",
      Email = "qv@medicalone.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Julia",
      LastName = "Asanov",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Mercy Mental Health - Saltwater Clinic",
        Location = new Address() {
         StreetNo = "94",
          Street = "Nicholson STREET",
          Suburb = "FOOTSCRAY",
          State = "Vic",
          PostCode = "3011"
        }
      },
      PhoneNumber = "03 9928 7444",
      Email = "Julia@MercyMentalHealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Rotimi Isaac",
      LastName = "Afolabi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Mildura Base Hospital",
        Location = new Address() {
         StreetNo = "231",
          Street = "Thirteenth STREET",
          Suburb = "MILDURA",
          State = "Vic",
          PostCode = "3500"
        }
      },
      PhoneNumber = "03 5022 3333",
      Email = "hoilesl@ramsayhealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Muhammad Ghazanfar",
      LastName = "Azhar",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Mind Over Muscle",
        Location = new Address() {
         StreetNo = "Level 2 377",
          Street = "Little Bourke STREET",
          Suburb = "MELBOURNE", State = "Vic",
          PostCode = "3000"
        }
      },
      PhoneNumber = "03 9670 9607",
      Email = "info@mindovermuscle.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "11am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "11am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "11am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "11am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "11am - 7pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Penelope Jane",
      LastName = "Analytis",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Mindful - Centre for Training and Reseach into Developmental Health",
        Location = new Address() {
         StreetNo = "Building C 50",
          Street = "Flemington STREET",
          Suburb = "TRAVANCORE",
          State = "Vic",
          PostCode = "3032"
        }
      },
      PhoneNumber = "03 9371 0200",
      Email = "mindful-info@unimelb.edu.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "David Colin",
      LastName = "Adam",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Monash Children's Hospital",
        Location = new Address() {
         StreetNo = "246",
          Street = "Clayton ROAD",
          Suburb = "CLAYTON",
          State = "Vic",
          PostCode = "3168"
        }
      },
      PhoneNumber = "03 8572 3000",
      Email = "monashchildrenshospital@monashhealth.org",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Anne Carol",
      LastName = "Appelbe",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Moorabbin Hospital",
        Location = new Address() {
         StreetNo = "823-865",
          Street = "Centre ROAD",
          Suburb = "BENTLEIGH EAST",
          State = "Vic",
          PostCode = "3165"
        }
      },
      PhoneNumber = "03 9928 8111",
      Email = "Appelbe@MoorabbinHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Jessica Eden",
      LastName = "Alabakis",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Myhealth Medical Centre - Point Cook",
        Location = new Address() {
         StreetNo = "225-229",
          Street = "Sneydes ROAD",
          Suburb = "POINT COOK",
          State = "Vic",
          PostCode = "3030"
        }
      },
      PhoneNumber = "03 8842 2880",
      Email = "pointcook.reception@myhealth.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 4pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Catherine Maria",
      LastName = "Adami",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "North Eastern Rehabilitation Centre - Ivanhoe",
        Location = new Address() {
         StreetNo = "134",
          Street = "Ford STREET",
          Suburb = "IVANHOE",
          State = "Vic",
          PostCode = "3079"
        }
      },
      PhoneNumber = "03 9474 8900",
      Email = "Adami@NorthEasternRehabilitationCentre.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Layla",
      LastName = "Asaf",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Northern Hospital",
        Location = new Address() {
         StreetNo = "185",
          Street = "Cooper STREET",
          Suburb = "EPPING",
          State = "Vic",
          PostCode = "3076"
        }
      },
      PhoneNumber = "03 8405 8000",
      Email = "corporatecommunications@nh.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Keith Viran",
      LastName = "Amarakone",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Northern Hospital",
        Location = new Address() {
         StreetNo = "185",
          Street = "Cooper STREET",
          Suburb = "EPPING",
          State = "Vic",
          PostCode = "3076"
        }
      },
      PhoneNumber = "03 8405 8000",
      Email = "corporatecommunications@nh.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ayman Youssef Chaker",
      LastName = "Aouad",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Northern Hospital",
        Location = new Address() {
         StreetNo = "185",
          Street = "Cooper STREET",
          Suburb = "EPPING",
          State = "Vic",
          PostCode = "3076"
        }
      },
      PhoneNumber = "03 8405 8000",
      Email = "corporatecommunications@nh.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Aadhil Waffarn",
      LastName = "Aziz",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Northpark Private Hospital",
        Location = new Address() {
         StreetNo = "Corner",
          Street = "Plenty and Greenhills ROAD",
          Suburb = "BUNDOORA",
          State = "Vic",
          PostCode = "3083"
        }
      },
      PhoneNumber = "03 9468 0100",
      Email = "simon.keating@healthscope.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Muslim Salman",
      LastName = "Asadi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Northpark Private Hospital",
        Location = new Address() {
         StreetNo = "Corner",
          Street = "Plenty and Greenhills ROAD",
          Suburb = "BUNDOORA",
          State = "Vic",
          PostCode = "3083"
        }
      },
      PhoneNumber = "03 9468 0100",
      Email = "simon.keating@healthscope.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "S M Shafiul",
      LastName = "Azam",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Northpark Private Hospital",
        Location = new Address() {
         StreetNo = "Corner",
          Street = "Plenty and Greenhills ROAD",
          Suburb = "BUNDOORA",
          State = "Vic",
          PostCode = "3083"
        }
      },
      PhoneNumber = "03 9468 0100",
      Email = "simon.keating@healthscope.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Neil Allan",
      LastName = "Africa",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Offshore Physiotherapy Torquay",
        Location = new Address() {
         StreetNo = "144",
          Street = "Surf Coast HIGHWAY",
          Suburb = "TORQUAY",
          State = "Vic",
          PostCode = "3228"
        }
      },
      PhoneNumber = "03 5261 5246",
      Email = "anthony@offshorephysiotorquay.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Kathleen",
      LastName = "Ager",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Open Care Pyschology - Epping",
        Location = new Address() {
         StreetNo = "24-26",
          Street = "Lyndarum DRIVE",
          Suburb = "EPPING",
          State = "Vic",
          PostCode = "3076"
        }
      },
      PhoneNumber = "03 9401 5118",
      Email = "info@opencarepsychology.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 3pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "1am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Emanuala Ogbagabr",
      LastName = "Araia",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Outside the Square Psychology",
        Location = new Address() {
         StreetNo = "20",
          Street = "Banksia STREET",
          Suburb = "BURWOOD",
          State = "Vic",
          PostCode = "3125"
        }
      },
      PhoneNumber = "03 9808 3917",
      Email = "info@outsidethesquarepsychology.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Emily Katherine",
      LastName = "Aylett",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Palmers Medical Centre",
        Location = new Address() {
         StreetNo = "228A",
          Street = "Sayers ROAD",
          Suburb = "TRUGANINA",
          State = "Vic",
          PostCode = "3029"
        }
      },
      PhoneNumber = "03 9908 2555",
      Email = "info@palmersmedical.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Edouard Joseph",
      LastName = "Ahkong",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Parkmore Physiotherapy Centre",
        Location = new Address() {
         StreetNo = "330",
          Street = "Cheltenham ROAD",
          Suburb = "KEYSBOROUGH",
          State = "Vic",
          PostCode = "3173"
        }
      },
      PhoneNumber = "03 9769 1677",
      Email = "parkphysio@bigpond.com",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Saad Abdullah Mohammad Al",
      LastName = "Noaman",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Peninsula Health - Frankston Hospital",
        Location = new Address() {
         StreetNo = "2",
          Street = "Hastings ROAD",
          Suburb = "FRANKSTON",
          State = "Vic",
          PostCode = "3199"
        }
      },
      PhoneNumber = "03 9784 7777",
      Email = "Noaman@PeninsulaHealthFrankston Hospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Shruti",
      LastName = "Anand",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Peninsula Health - Frankston Hospital",
        Location = new Address() {
         StreetNo = "2",
          Street = "Hastings ROAD",
          Suburb = "FRANKSTON",
          State = "Vic",
          PostCode = "3199"
        }
      },
      PhoneNumber = "03 9784 7777",
      Email = "Anand@PeninsulaHealthFrankston Hospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "David Francis",
      LastName = "Awburn",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Peninsula Health - Frankston Hospital",
        Location = new Address() {
         StreetNo = "2",
          Street = "Hastings ROAD",
          Suburb = "FRANKSTON",
          State = "Vic",
          PostCode = "3199"
        }
      },
      PhoneNumber = "03 9784 7777",
      Email = "Awburn@PeninsulaHealthFrankston Hospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Tai-Juan",
      LastName = "Aw",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Peninsula Private Hospital - Victoria",
        Location = new Address() {
         StreetNo = "525",
          Street = "Mcclelland DRIVE",
          Suburb = "LANGWARRIN",
          State = "Vic",
          PostCode = "3910"
        }
      },
      PhoneNumber = "03 9788 3466",
      Email = "Aw@PeninsulaPrivateHospitalVictoria.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Adam Yusuf",
      LastName = "Abbas",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Physio And Fitness Clinic",
        Location = new Address() {
         StreetNo = "112",
          Street = "Nepean HIGHWAY",
          Suburb = "SEAFORD",
          State = "Vic",
          PostCode = "3198"
        }
      },
      PhoneNumber = "03 9786 6642",
      Email = "info@physioandfitnessclinic.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Yin Min",
      LastName = "Aye",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Physio First - Epping",
        Location = new Address() {
         StreetNo = "230",
          Street = "Cooper STREET",
          Suburb = "EPPING", State = "Vic",
          PostCode = "3076"
        }
      },
      PhoneNumber = "03 8401 1500",
      Email = "admin@physiofirst.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Tuba",
      LastName = "Atalmis",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "PVH Medical",
        Location = new Address() {
         StreetNo = "124",
          Street = "Kent ROAD",
          Suburb = "PASCOE VALE", State = "Vic",
          PostCode = "3044"
        }
      },
      PhoneNumber = "03 9304 0500",
      Email = "info@pvhmedical.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Donal Colm",
      LastName = "Ahern",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Recover Sports Medicine - Richmond",
        Location = new Address() {
         StreetNo = "Level 1 560",
          Street = "Church STREET",
          Suburb = "RICHMOND", State = "Vic",
          PostCode = "3121"
        }
      },
      PhoneNumber = "1300 858 774",
      Email = "contact@recoversportsmed.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 4pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 3pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Joanna Izabela",
      LastName = "Adamowicz",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Ringwood Counselling Centre",
        Location = new Address() {
         StreetNo = "10",
          Street = "Bondi STREET",
          Suburb = "RINGWOOD EAST", State = "Vic",
          PostCode = "3135"
        }
      },
      PhoneNumber = "03 9870 4464",
      Email = "patgreig3@bigpond.com",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ileanne",
      LastName = "Au",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Ringwood East Spinal And Sports Physiotherapy Centre",
        Location = new Address() {
         StreetNo = "68",
          Street = "Railway AVENUE",
          Suburb = "RINGWOOD EAST", State = "Vic",
          PostCode = "3135"
        }
      },
      PhoneNumber = "03 9879 4544",
      Email = "info@ringwoodeastphysio.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ezgi",
      LastName = "Akar",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Rosanna Medical Centre",
        Location = new Address() {
         StreetNo = "327",
          Street = "Greensborough ROAD",
          Suburb = "WATSONIA", State = "Vic",
          PostCode = "3087"
        }
      },
      Email = "EzgiAkar@RosannaMedicalCentre.com.au",
      PhoneNumber = "03 9435 1191",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Barry David",
      LastName = "Akers",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Rosebud Physiotherapy Clinic",
        Location = new Address() {
         StreetNo = "42-44",
          Street = "Boneo ROAD",
          Suburb = "ROSEBUD", State = "Vic",
          PostCode = "3939"
        }
      },
      PhoneNumber = "03 5986 3655",
      Email = "info@psmgroup.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ilker Remzi",
      LastName = "Abak",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Roxburgh Park Superclinic",
        Location = new Address() {
         StreetNo = "Shop 1 Roxburgh Park Homestead Shopping Centre - 101",
          Street = "Ravenhill BOULEVARD",
          Suburb = "ROXBURGH PARK", State = "Vic",
          PostCode = "3064"
        }
      },
      PhoneNumber = "03 9308 7088",
      Email = "roxburghpark@alliedmgp.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Andreia Cristiana",
      LastName = "Azevedo",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "SALTIE",
        Location = new Address() {
         StreetNo = "113",
          Street = "Watsonia ROAD",
          Suburb = "WATSONIA", State = "Vic",
          PostCode = "3087"
        }
      },
      PhoneNumber = "03 9434 4161",
      Email = "info@saltie.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sarah Chaturi",
      LastName = "Arachchi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "St John of God Ballarat Hospital",
        Location = new Address() {
         StreetNo = "101",
          Street = "Drummond STREET",
          Suburb = "BALLARAT", State = "Vic",
          PostCode = "3350"
        }
      },
      PhoneNumber = "03 5320 2111",
      Email = "info.ballarat@sjog.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Neil Allan",
      LastName = "Africa",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "St John Of God Hospital - Geelong",
        Location = new Address() {
         StreetNo = "80",
          Street = "Myers STREET",
          Suburb = "GEELONG", State = "Vic",
          PostCode = "3220"
        }
      },
      PhoneNumber = "03 5226 8888",
      Email = "info.geelong@sjog.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Julie Carol",
      LastName = "Avery",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "St John Of God Warrnambool Hospital - Health Services Centre",
        Location = new Address() {
         StreetNo = "136",
          Street = "Botanic ROAD",
          Suburb = "WARRNAMBOOL", State = "Vic",
          PostCode = "3280"
        }
      },
      PhoneNumber = "03 5563 4555",
      Email = "info@sjog.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:15am - 4:45pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Michelle Renuka",
      LastName = "Ananda-Rajah",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "St Vincents Hospital",
        Location = new Address() {
         StreetNo = "41",
          Street = "Victoria PARADE",
          Suburb = "FITZROY", State = "Vic",
          PostCode = "3065"
        }
      },
      PhoneNumber = "03 9231 2211",
      Email = "Ananda-Ra@StVincentsHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sharon Rae",
      LastName = "Avery",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "St Vincents Hospital",
        Location = new Address() {
         StreetNo = "41",
          Street = "Victoria PARADE",
          Suburb = "FITZROY", State = "Vic",
          PostCode = "3065"
        }
      },
      PhoneNumber = "03 9231 2211",
      Email = "Avery@StVincentsHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Belle Jayanth",
      LastName = "Achar",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "St Vincents Hospital",
        Location = new Address() {
         StreetNo = "41",
          Street = "Victoria PARADE",
          Suburb = "FITZROY", State = "Vic",
          PostCode = "3065"
        }
      },
      PhoneNumber = "03 9231 2211",
      Email = "Achar@StVincentsHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Mahsa",
      LastName = "Adabi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "St Vincents Hospital",
        Location = new Address() {
         StreetNo = "41",
          Street = "Victoria PARADE",
          Suburb = "FITZROY", State = "Vic",
          PostCode = "3065"
        }
      },
      Email = "MahsaAdabi@StVincentsHospital.com.au",
      PhoneNumber = "03 9231 2211",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Afshin",
      LastName = "Agahi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "St Vincents Hospital",
        Location = new Address() {
         StreetNo = "41",
          Street = "Victoria PARADE",
          Suburb = "FITZROY", State = "Vic",
          PostCode = "3065"
        }
      },
      Email = "AfshinAgahi@StVincentsHospital.com.au",
      PhoneNumber = "03 9231 2211",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Mark Andrew",
      LastName = "Avery",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Sunshine Hospital",
        Location = new Address() {
         StreetNo = "176",
          Street = "Furlong ROAD",
          Suburb = "ST ALBANS", State = "Vic",
          PostCode = "3021"
        }
      },
      PhoneNumber = "03 8345 1559",
      Email = "Avery@SunshineHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Linda Shelley",
      LastName = "Appiah-Kubi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Sunshine Hospital",
        Location = new Address() {
         StreetNo = "176",
          Street = "Furlong ROAD",
          Suburb = "ST ALBANS", State = "Vic",
          PostCode = "3021"
        }
      },
      PhoneNumber = "03 8345 1730",
      Email = "Appiah@SunshineHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Gamal",
      LastName = "Awad",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Sunshine Hospital",
        Location = new Address() {
         StreetNo = "176",
          Street = "Furlong ROAD",
          Suburb = "ST ALBANS", State = "Vic",
          PostCode = "3021"
        }
      },
      PhoneNumber = "03 8345 1730",
      Email = "Awad@SunshineHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Magdy Heshmat Shafik",
      LastName = "Azer",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Sunshine Hospital",
        Location = new Address() {
         StreetNo = "176",
          Street = "Furlong ROAD",
          Suburb = "ST ALBANS", State = "Vic",
          PostCode = "3021"
        }
      },
      PhoneNumber = "03 8345 1730",
      Email = "Azer@SunshineHospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Brad Steven",
      LastName = "Avery",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Swanston Street Medical Centre",
        Location = new Address() {
         StreetNo = "Level 3 255",
          Street = "Bourke STREET",
          Suburb = "MELBOURNE", State = "Vic",
          PostCode = "3000"
        }
      },
      PhoneNumber = "03 9205 7500",
      Email = "linda.pullen@healthscope.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Karin Linnea",
      LastName = "Axelsson",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Symmetry Physiotherapy",
        Location = new Address() {
         StreetNo = "101",
          Street = "Beach STREET",
          Suburb = "PORT MELBOURNE",
          State = "Vic",
          PostCode = "3207"
        }
      },
      PhoneNumber = "03 9676 9139",
      Email = "Axelsson@SymmetryPhysiotherapy.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Brooke",
      LastName = "Adair",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "The Gertrude Street Clinic",
        Location = new Address() {
         StreetNo = "16",
          Street = "Gertrude STREET",
          Suburb = "FITZROY",
          State = "Vic",
          PostCode = "3065"
        }
      },
      PhoneNumber = "03 9419 3001",
      Email = "Adair@TheGertrudeStreetClinic.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Kirsten",
      LastName = "Audehm",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "The Kilmore And District Hospital",
        Location = new Address() {
         StreetNo = "",
          Street = "Rutledge STREET",
          Suburb = "KILMORE",
          State = "Vic",
          PostCode = "3764"
        }
      },
      PhoneNumber = "03 5734 2000",
      Email = "kilmorewc@humehealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Luke",
      LastName = "Ainsworth",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Melbourne Clinic",
        Location = new Address() {
         StreetNo = "130",
          Street = "Church STREET",
          Suburb = "RICHMOND",
          State = "Vic",
          PostCode = "3121"
        }
      },
      PhoneNumber = "03 9429 4688",
      Email = "tmc@healthscope.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Resha",
      LastName = "Abbas",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Melbourne Eastern Private Hospital",
        Location = new Address() {
         StreetNo = "157",
          Street = "Scoresby ROAD",
          Suburb = "BORONIA",
          State = "Vic",
          PostCode = "3155"
        }
      },
      Email = "info@mountaindistrictprivate.com.au",
      PhoneNumber = "03 9839 3300",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 1pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Bhavya Harshadray",
      LastName = "Adalja",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "The Physiotherapy & Sports Therapy Clinic",
        Location = new Address() {
         StreetNo = "5",
          Street = "Boardwalk BOULEVARD",
          Suburb = "POINT COOK",
          State = "Vic",
          PostCode = "3030"
        }
      },
      Email = "info@physiopointcook.com.au",
      PhoneNumber = "03 9395 2048",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 6pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Andrew Edward",
      LastName = "Ajani",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Royal Children's Hospital",
        Location = new Address() {
         StreetNo = "50",
          Street = "Flemington ROAD",
          Suburb = "PARKVILLE",
          State = "Vic",
          PostCode = "3052"
        }
      },
      Email = "AndrewEdward@TheRoyalChildrensHospital.com.au",
      PhoneNumber = "03 9345 5522",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Alexis",
      LastName = "Adamides",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Royal Children's Hospital",
        Location = new Address() {
         StreetNo = "50",
          Street = "Flemington ROAD",
          Suburb = "PARKVILLE",
          State = "Vic",
          PostCode = "3052"
        }
      },
      Email = "Alexis@TheRoyalChildrensHospital.com.au",
      PhoneNumber = "03 9345 5522",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ali Haider Talb Hamad Al",
      LastName = "Joboory",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Royal Children's Hospital",
        Location = new Address() {
         StreetNo = "50",
          Street = "Flemington ROAD",
          Suburb = "PARKVILLE",
          State = "Vic",
          PostCode = "3052"
        }
      },
      Email = "Ali@TheRoyalChildrensHospital.com.au",
      PhoneNumber = "03 9345 5522",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sachin",
      LastName = "Agarwal",
      Service = _serviceList[1],
      Facility = new Facility() {
       FacilityName = "The Royal Dental Hospital of Melbourne",
        Location = new Address() {
         StreetNo = "720",
          Street = "Swanston STREET",
          Suburb = "CARLTON", State = "Vic",
          PostCode = "3053"
        }
      },
      PhoneNumber = "03 9341 1163",
      Email = "enquiries@dhsv.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },




    new MedicalProfessional() {
     FirstMidName = "Leonardo",
      LastName = "Acevedo",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Royal Melbourne Hospital - Royal Park Campus",
        Location = new Address() {
         StreetNo = "34-54",
          Street = "Poplar ROAD",
          Suburb = "PARKVILLE",
          State = "Vic",
          PostCode = "3052"
        }
      },
      Email = "enquiries@mh.org.au",
      PhoneNumber = "03 8387 2000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Romani Yacoub",
      LastName = "Agaibi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Royal Melbourne Hospital - Royal Park Campus",
        Location = new Address() {
         StreetNo = "34-54",
          Street = "Poplar ROAD",
          Suburb = "PARKVILLE",
          State = "Vic",
          PostCode = "3052"
        }
      },
      Email = "enquiries@mh.org.au",
      PhoneNumber = "03 8387 2000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      } 
    },
    new MedicalProfessional() {
     FirstMidName = "Jonathan",
      LastName = "Ajzner",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Royal Melbourne Hospital - Royal Park Campus",
        Location = new Address() {
         StreetNo = "34-54",
          Street = "Poplar ROAD",
          Suburb = "PARKVILLE",
          State = "Vic",
          PostCode = "3052"
        }
      },
      Email = "enquiries@mh.org.au",
      PhoneNumber = "03 8387 2000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Trudy",
      LastName = "Ainsmith",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "The Talk Shop - Kew",
        Location = new Address() {
         StreetNo = "194",
          Street = "High STREET",
          Suburb = "KEW",
          State = "Vic",
          PostCode = "3101"
        }
      },
      Email = "admin@thetalkshop.com.au",
      PhoneNumber = "13 00 224 665",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Pratap Chandra",
      LastName = "Acharya",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Victoria Clinic",
        Location = new Address() {
         StreetNo = "324",
          Street = "Malvern ROAD",
          Suburb = "PRAHRAN",
          State = "Vic",
          PostCode = "3181"
        }
      },
      Email = "Pratap@The Victoria Clinic.com.au",
      PhoneNumber = "03 9526 0200",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Abdallah Mohamed",
      LastName = "Arakji",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Williamstown Hospital",
        Location = new Address() {
         StreetNo = "77B",
          Street = "Railway CRESCENT",
          Suburb = "WILLIAMSTOWN",
          State = "Vic",
          PostCode = "3016"
        }
      },
      Email = "Abdallah@The Williamstown Hospital.com.au",
      PhoneNumber = "03 9393 0100",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Anupama",
      LastName = "Achar",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "The Williamstown Hospital",
        Location = new Address() {
         StreetNo = "77B",
          Street = "Railway CRESCENT",
          Suburb = "WILLIAMSTOWN",
          State = "Vic",
          PostCode = "3016"
        }
      },
      Email = "Anupama@The Williamstown Hospital.com.au",
      PhoneNumber = "03 9393 0100",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Se-Jin",
      LastName = "An",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Transform Physio - Dandenong North",
        Location = new Address() {
         StreetNo = "65",
          Street = "Brady ROAD",
          Suburb = "DANDENONG NORTH",
          State = "Vic",
          PostCode = "3175"
        }
      },
      Email = "community@transformphysio.com.au",
      PhoneNumber = "1300 904 907",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Rachele Anne",
      LastName = "Aiello",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Tunstall Square Family Medical Centre",
        Location = new Address() {
         StreetNo = "2",
          Street = "Mitcham ROAD",
          Suburb = "DONVALE",
          State = "Vic",
          PostCode = "3111"
        }
      },
      Email = "Rachele@TunstallSquareFamilyMedicalCentre.com.au",
      PhoneNumber = "03 9842 7700",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Jayda Aleyna",
      LastName = "Akder",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Tunstall Square Family Medical Centre",
        Location = new Address() {
         StreetNo = "2",
          Street = "Mitcham ROAD",
          Suburb = "DONVALE",
          State = "Vic",
          PostCode = "3111"
        }
      },
      Email = "Jayda@TunstallSquareFamilyMedicalCentre.com.au",
      PhoneNumber = "03 9842 7700",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Reem Yousef Al",
      LastName = "Hanna",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "University Hospital Geelong",
        Location = new Address() {
         StreetNo = "272-322",
          Street = "Ryrie STREET",
          Suburb = "GEELONG",
          State = "Vic",
          PostCode = "3220"
        }
      },
      Email = "postmaster@barwonhealth.org.au",
      PhoneNumber = "03 4215 0000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "John William MacDonald",
      LastName = "Agar",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "University Hospital Geelong",
        Location = new Address() {
         StreetNo = "272-322",
          Street = "Ryrie STREET",
          Suburb = "GEELONG",
          State = "Vic",
          PostCode = "3220"
        }
      },
      Email = "postmaster@barwonhealth.org.au",
      PhoneNumber = "03 4215 0000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Nicholas John MacDonald",
      LastName = "Agar",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "University Hospital Geelong",
        Location = new Address() {
         StreetNo = "272-322",
          Street = "Ryrie STREET",
          Suburb = "GEELONG",
          State = "Vic",
          PostCode = "3220"
        }
      },
      Email = "postmaster@barwonhealth.org.au",
      PhoneNumber = "03 4215 0000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Eseta Susana",
      LastName = "Akers",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "University Hospital Geelong",
        Location = new Address() {
         StreetNo = "272-322",
          Street = "Ryrie STREET",
          Suburb = "GEELONG",
          State = "Vic",
          PostCode = "3220"
        }
      },
      Email = "postmaster@barwonhealth.org.au",
      PhoneNumber = "03 4215 0000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Alan Frederick",
      LastName = "Appelbe",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "University Hospital Geelong",
        Location = new Address() {
         StreetNo = "272-322",
          Street = "Ryrie STREET",
          Suburb = "GEELONG",
          State = "Vic",
          PostCode = "3220"
        }
      },
      Email = "postmaster@barwonhealth.org.au",
      PhoneNumber = "03 4215 0000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Eugene",
      LastName = "Athan",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "University Hospital Geelong",
        Location = new Address() {
         StreetNo = "272-322",
          Street = "Ryrie STREET",
          Suburb = "GEELONG",
          State = "Vic",
          PostCode = "3220"
        }
      },
      Email = "postmaster@barwonhealth.org.au",
      PhoneNumber = "03 4215 0000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Chaw Yu Par",
      LastName = "Aye",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "University Hospital Geelong",
        Location = new Address() {
         StreetNo = "272-322",
          Street = "Ryrie STREET",
          Suburb = "GEELONG",
          State = "Vic",
          PostCode = "3220"
        }
      },
      Email = "postmaster@barwonhealth.org.au",
      PhoneNumber = "03 4215 0000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Burcu",
      LastName = "Akdeniz",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Victorian Counselling & Psychological Services - Coolaroo",
        Location = new Address() {
         StreetNo = "510",
          Street = "Barry ROAD",
          Suburb = "COOLAROO",
          State = "Vic",
          PostCode = "3048"
        }
      },
      Email = "reception@vcps.com.au",
      PhoneNumber = "02 9419 7172",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Aysen",
      LastName = "Akdenk-Ozgurler",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Victorian Counselling & Psychological Services - Coolaroo",
        Location = new Address() {
         StreetNo = "510",
          Street = "Barry ROAD",
          Suburb = "COOLAROO",
          State = "Vic",
          PostCode = "3048"
        }
      },
      Email = "reception@vcps.com.au",
      PhoneNumber = "02 9419 7172",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Khashayar",
      LastName = "Asadi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Warringal Private Hospital",
        Location = new Address() {
         StreetNo = "216",
          Street = "Burgundy STREET",
          Suburb = "HEIDELBERG",
          State = "Vic",
          PostCode = "3084"
        }
      },
      Email = "Khashayar@WarringalPrivateHospital.com.au",
      PhoneNumber = "03 9274 1300",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Monika",
      LastName = "Acevski",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Watergardens Medical Centre",
        Location = new Address() {
         StreetNo = "Shop 23-24 399",
          Street = "Melton HIGHWAY",
          Suburb = "TAYLORS LAKES",
          State = "Vic",
          PostCode = "3038"
        }
      },
      Email = "399.wgmc@gmail.com",
      PhoneNumber = "03 9449 3636",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "10am - 2pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Wendy Wee Gnoh Ah",
      LastName = "Sang",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Waverley Private Hospital",
        Location = new Address() {
         StreetNo = "357",
          Street = "Blackburn ROAD",
          Suburb = "MOUNT WAVERLEY",
          State = "Vic",
          PostCode = "3149"
        }
      },
      Email = "waverleyoffice.wvp@ramsayhealth.com.au",
      PhoneNumber = "03 9881 7700",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Huma",
      LastName = "Ajmal",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Werribee Mercy Hospital",
        Location = new Address() {
         StreetNo = "300",
          Street = "Princes HIGHWAY",
          Suburb = "WERRIBEE",
          State = "Vic",
          PostCode = "3030"
        }
      },
      Email = "werribee@mercy.com.au",
      PhoneNumber = "03 8754 3000",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ahmad Mansour",
      LastName = "Ahmad",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "West Gippsland Healthcare Group Hospital",
        Location = new Address() {
         StreetNo = "41",
          Street = "Landsborough STREET",
          Suburb = "WARRAGUL",
          State = "Vic",
          PostCode = "3820"
        }
      },
      Email = "Ahmad@WestGippslandHealthcareGroupHospital.com.au",
      PhoneNumber = "03 5623 0611",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Mohammed Al",
      LastName = "Kamil",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Western Private Hospital",
        Location = new Address() {
         StreetNo = "1",
          Street = "Marion STREET",
          Suburb = "FOOTSCRAY",
          State = "Vic",
          PostCode = "3011"
        }
      },
      Email = "Mohammed@WesternPrivateHospital.com.au",
      PhoneNumber = "03 9318 3177",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "6am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Cristian John",
      LastName = "Acciarito",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Wheelers Hill Clinic",
        Location = new Address() {
         StreetNo = "847",
          Street = "Ferntree Gully ROAD",
          Suburb = "WHEELERS HILL",
          State = "Vic",
          PostCode = "3150"
        }
      },
      Email = "admin@whclinic.com.au",
      PhoneNumber = "03 9561 3200",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Chigozie",
      LastName = "Agbarakwe",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Wyndham Clinic Private Hospital",
        Location = new Address() {
         StreetNo = "242A",
          Street = "Hoppers LANE",
          Suburb = "WERRIBEE",
          State = "Vic",
          PostCode = "3030"
        }
      },
      Email = "info@wyndhamclinic.com.au",
      PhoneNumber = "03 9731 6646",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "7am - 6pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Tahjibul",
      LastName = "Anam",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Wyndham Clinic Private Hospital",
        Location = new Address() {
         StreetNo = "242A",
          Street = "Hoppers LANE",
          Suburb = "WERRIBEE",
          State = "Vic",
          PostCode = "3030"
        }
      },
      Email = "info@wyndhamclinic.com.au",
      PhoneNumber = "03 9731 6646",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "7am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "7am - 6pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Navid",
      LastName = "Afsharipour",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Yarra Ranges Health",
        Location = new Address() {
         StreetNo = "25",
          Street = "Market STREET",
          Suburb = "LILYDALE",
          State = "Vic",
          PostCode = "3140"
        }
      },
      Email = "yarrarangeshealth@easternhealth.org.au",
      PhoneNumber = "1300 342 255",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Conrad Wells Hamilton",
      LastName = "Aikin",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Australian College Of Psychologists In Clinical Private Practice - Brunswick",
        Location = new Address() {
         StreetNo = "2",
          Street = "Errol AVENUE",
          Suburb = "BRUNSWICK",
          State = "Vic",
          PostCode = "3056"
        }
      },
      PhoneNumber = "03 9380 6025",
      Email = "acpcpp@psychologistsvictoria.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Natasha Danielle",
      LastName = "Ascenzo",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "australian College Of Psychologists In Clinical Private Practice - Brunswick",
        Location = new Address() {
         StreetNo = "2",
          Street = "Errol AVENUE",
          Suburb = "BRUNSWICK", State = "Vic",
          PostCode = "3056"
        }
      },
      PhoneNumber = "03 9380 6025",
      Email = "acpcpp@psychologistsvictoria.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Steven",
      LastName = "Ajzenman",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Back In Motion - Mentone",
        Location = new Address() {
         StreetNo = "11",
          Street = "Como PARADE",
          Suburb = "MENTONE", State = "Vic",
          PostCode = "3194"
        }
      },
      PhoneNumber = "03 9872 4141",
      Email = "mentone@backinmotion.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Joanne Francene",
      LastName = "Airey",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Back In Motion Health Group - Blackburn",
        Location = new Address() {
         StreetNo = "Suite 3 130",
          Street = "South PARADE",
          Suburb = "BLACKBURN", State = "Vic",
          PostCode = "3130"
        }
      },
      PhoneNumber = "03 9878 1919",
      Email = "blackburn@backinmotion.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Douraid",
      LastName = "Abbas",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Ballarat Health Services - Base Hospital",
        Location = new Address() {
         StreetNo = "1",
          Street = "Drummond STREET",
          Suburb = "BALLARAT", State = "Vic",
          PostCode = "3350"
        }
      },
      PhoneNumber = "03 5320 4000",
      Email = "info@bhs.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "William Robert St John",
      LastName = "Ainslie",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Ballarat Health Services - Base Hospital",
        Location = new Address() {
         StreetNo = "1",
          Street = "Drummond STREET",
          Suburb = "BALLARAT", State = "Vic",
          PostCode = "3350"
        }
      },
      PhoneNumber = "03 5320 4000",
      Email = "info@bhs.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ayhan",
      LastName = "Ada",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Barwon Health - McKellar Centre",
        Location = new Address() {
         StreetNo = "45-95",
          Street = "Ballarat ROAD",
          Suburb = "NORTH GEELONG", State = "Vic",
          PostCode = "3215"
        }
      },
      PhoneNumber = "03 4215 5200",
      Email = "postmaster@barwonhealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Jordana",
      LastName = "Aamalia",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Bayside Medical Group - Hampton",
        Location = new Address() {
         StreetNo = "3",
          Street = "Service STREET",
          Suburb = "HAMPTON", State = "Vic",
          PostCode = "3188"
        }
      },
      PhoneNumber = "03 9598 9911",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ariana",
      LastName = "Axarlis",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Beachbox Physiotherapy",
        Location = new Address() {
         StreetNo = "133",
          Street = "Nepean HIGHWAY",
          Suburb = "SEAFORD", State = "Vic",
          PostCode = "3198"
        }
      },
      PhoneNumber = "03 9036 7700",
      Email = "enquiries@beachboxphysiotherapy.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Adeola Oluwatosin Kofoworola",
      LastName = "Akadiri",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Beleura Private Hospital",
        Location = new Address() {
         StreetNo = "925",
          Street = "Nepean HIGHWAY",
          Suburb = "MORNINGTON", State = "Vic",
          PostCode = "3931"
        }
      },
      PhoneNumber = "03 5976 0888",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "6am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Natasha Jane",
      LastName = "Aylen",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Beleura Private Hospital",
        Location = new Address() {
         StreetNo = "925",
          Street = "Nepean HIGHWAY",
          Suburb = "MORNINGTON", State = "Vic",
          PostCode = "3931"
        }
      },
      PhoneNumber = "03 5976 0888",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "6am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "6am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Shama",
      LastName = "Aradhye",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bellbird Private Hospital",
        Location = new Address() {
         StreetNo = "198",
          Street = "Canterbury ROAD",
          Suburb = "BLACKBURN", State = "Vic",
          PostCode = "3130"
        }
      },
      PhoneNumber = "03 9845 2333",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Poornima",
      LastName = "Amaranarayana",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bendigo Health - Bendigo Hospital",
        Location = new Address() {
         StreetNo = "100",
          Street = "Barnard STREET",
          Suburb = "BENDIGO", State = "Vic",
          PostCode = "3552"
        }
      },
      PhoneNumber = "03 5454 6000",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Adel Seliem Sabry",
      LastName = "Asaid",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bendigo Health - Bendigo Hospital",
        Location = new Address() {
         StreetNo = "100",
          Street = "Barnard STREET",
          Suburb = "BENDIGO", State = "Vic",
          PostCode = "3552"
        }
      },
      PhoneNumber = "03 5454 6000",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Anju",
      LastName = "Agarwal",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Bendigo Health - Bendigo Hospital",
        Location = new Address() {
         StreetNo = "100",
          Street = "Barnard STREET",
          Suburb = "BENDIGO", State = "Vic",
          PostCode = "3552"
        }
      },
      PhoneNumber = "03 5454 9184",
      Email = "ereferral@bendigohealth.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "11am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "3pm - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "11am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Anamalay",
      LastName = "Ayasamy",
      Service = _serviceList[1],
      Facility = new Facility() {
       FacilityName = "Beyond Smiles Dentistry",
        Location = new Address() {
         StreetNo = "Suite 3 572",
          Street = "Main STREET",
          Suburb = "MORDIALLOC", State = "Vic",
          PostCode = "3195"
        }
      },
      PhoneNumber = "03 9580 1100",
      Email = "admin@beyondsmiles.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Sarpreet Kaur",
      LastName = "Anand",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Bodyline Health",
        Location = new Address() {
         StreetNo = "17",
          Street = "Main ROAD",
          Suburb = "LOWER PLENTY", State = "Vic",
          PostCode = "3093"
        }
      },
      PhoneNumber = "03 9017 4784",
      Email = "info@bodylinehealth.com",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - midday"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "2pm - 7pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Susan Maria",
      LastName = "Athaide",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Brighton Psychology Centre",
        Location = new Address() {
         StreetNo = "175",
          Street = "Bay STREET",
          Suburb = "BRIGHTON", State = "Vic",
          PostCode = "3186"
        }
      },
      PhoneNumber = "03 9596 8844",
      Email = "bpc@brightpsych.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Jawaria",
      LastName = "Avais",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Broadmeadows Health Service",
        Location = new Address() {
         StreetNo = "35",
          Street = "Johnstone STREET",
          Suburb = "BROADMEADOWS", State = "Vic",
          PostCode = "3047"
        }
      },
      PhoneNumber = "03 8345 5000",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Martin Rolf",
      LastName = "Axelsson",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Brooke Street Medical Centre",
        Location = new Address() {
         StreetNo = "14",
          Street = "Brooke STREET",
          Suburb = "WOODEND", State = "Vic",
          PostCode = "3442"
        }
      },
      PhoneNumber = "03 5427 1002",
      Email = "bsmc@bsmc.net.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 4pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 4pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 3:30pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 3:30pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Riccardo",
      LastName = "Abad",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Burnside Medical Centre",
        Location = new Address() {
         StreetNo = "Shop 19/25",
          Street = "Westwood DRIVE",
          Suburb = "BURNSIDE", State = "Vic",
          PostCode = "3023"
        }
      },
      PhoneNumber = "03 9363 6766",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Manju",
      LastName = "Agarwal",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Cabrini Hospital - Brighton",
        Location = new Address() {
         StreetNo = "243",
          Street = "New STREET",
          Suburb = "BRIGHTON", State = "Vic",
          PostCode = "3186"
        }
      },
      PhoneNumber = "03 9508 8777",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "7am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "7am - 8pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ahmad",
      LastName = "Aga",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Cabrini Hospital - Malvern",
        Location = new Address() {
         StreetNo = "183",
          Street = "Wattletree ROAD",
          Suburb = "MALVERN", State = "Vic",
          PostCode = "3144"
        }
      },
      PhoneNumber = "03 9508 1222",
      Email = "admin@cabrini.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Biola Morenike",
      LastName = "Araba",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Cabrini Hospital - Malvern",
        Location = new Address() {
         StreetNo = "183",
          Street = "Wattletree ROAD",
          Suburb = "MALVERN", State = "Vic",
          PostCode = "3144"
        }
      },
      PhoneNumber = "03 9508 1222",
      Email = "admin@cabrini.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Kerry",
      LastName = "Athanasiadis",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Camberwell Counselling",
        Location = new Address() {
         StreetNo = "Level 1 760",
          Street = "Riversdale ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      PhoneNumber = "0404 082 675",
      Email = "help@camberwellcounselling.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Trish",
      LastName = "Ayers",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Camberwell Counselling",
        Location = new Address() {
         StreetNo = "Level 1 760",
          Street = "Riversdale ROAD",
          Suburb = "CAMBERWELL", State = "Vic",
          PostCode = "3124"
        }
      },
      PhoneNumber = "0404 082 675",
      Email = "help@camberwellcounselling.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Chanelle",
      LastName = "Adam",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Carol Schulz - Clinical and Counselling Psychologist",
        Location = new Address() {
         StreetNo = "176",
          Street = "Beach STREET",
          Suburb = "FRANKSTON", State = "Vic",
          PostCode = "3199"
        }
      },
      PhoneNumber = "03 9781 0600",
      Email = "carol.schulz.maps@gmail.com",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Amena",
      LastName = "Azizi",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      PhoneNumber = "03 8768 1200",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Indu Udayamali Amarakoon",
      LastName = "Mudiyanselage",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      PhoneNumber = "03 8768 1200",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Ali",
      LastName = "Asadpour",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      PhoneNumber = "03 8768 1200",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Allan Chung Yan",
      LastName = "Au",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Casey Hospital",
        Location = new Address() {
         StreetNo = "62",
          Street = "Kangan DRIVE",
          Suburb = "BERWICK", State = "Vic",
          PostCode = "3806"
        }
      },
      PhoneNumber = "03 8768 1200",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Hesham",
      LastName = "Azer",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Churinga Medical Centre",
        Location = new Address() {
         StreetNo = "465",
          Street = "Mt Dandenong ROAD",
          Suburb = "KILSYTH", State = "Vic",
          PostCode = "3137"
        }
      },
      PhoneNumber = "03 9722 9888",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 7pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "9am - 6pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "8am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Marisa Gianna",
      LastName = "Abate",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Churinga Medical Centre",
        Location = new Address() {
         StreetNo = "465",
          Street = "Mt Dandenong ROAD",
          Suburb = "KILSYTH", State = "Vic",
          PostCode = "3137"
        }
      },
      PhoneNumber = "03 9722 9888",
      Email = "",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Amali Indika",
      LastName = "Abayawardana",
      Service = _serviceList[4],
      Facility = new Facility() {
       FacilityName = "Corazon Centre Inc.",
        Location = new Address() {
         StreetNo = "11",
          Street = "Mortimer STREET",
          Suburb = "WERRIBEE", State = "Vic",
          PostCode = "3030"
        }
      },
      PhoneNumber = "03 9974 2756",
      Email = "contact@corazon.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "9am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "9am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Lee",
      LastName = "Ajzenman",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Core Physio & Pilates",
        Location = new Address() {
         StreetNo = "Level 2 370",
          Street = "Glen Huntly ROAD",
          Suburb = "ELSTERNWICK", State = "Vic",
          PostCode = "3185"
        }
      },
      PhoneNumber = "03 9523 8111",
      Email = "info@coremelbourne.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "7am - 9pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "7am - 1pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7am - 1pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Catherina",
      LastName = "Audish",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Craigieburn Health Service",
        Location = new Address() {
         StreetNo = "274-304",
          Street = "Craigieburn ROAD",
          Suburb = "CRAIGIEBURN", State = "Vic",
          PostCode = "3064"
        }
      },
      PhoneNumber = "03 8338 3030",
      Email = "corporatecommunication@nh.org.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8am - 5pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8am - 5pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Rani Sharina Kay",
      LastName = "Axtens",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Delmont Private Hospital",
        Location = new Address() {
         StreetNo = "298-306",
          Street = "Warrigal ROAD",
          Suburb = "GLEN IRIS", State = "Vic",
          PostCode = "3146"
        }
      },
      PhoneNumber = "03 9805 7333",
      Email = "delmont@delmonthospital.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Sunday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "12am - 12pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "12am - 12pm"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Linda",
      LastName = "Aykut",
      Service = _serviceList[0],
      Facility = new Facility() {
       FacilityName = "Donvale Rehabilitation Hospital",
        Location = new Address() {
         StreetNo = "1119",
          Street = "Doncaster ROAD",
          Suburb = "DONVALE", State = "Vic",
          PostCode = "3111"
        }
      },
      PhoneNumber = "03 9841 1400",
      Email = "front.drh@ramsayhealth.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Monday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Wednesday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Friday",
         Hours = "8:30am - 8pm"
       },
       new HoursActive() {
        WeekDays = "Saturday",
         Hours = "7:30am - midday"
       }
      }
    },
    new MedicalProfessional() {
     FirstMidName = "Anne",
      LastName = "Africa",
      Service = _serviceList[3],
      Facility = new Facility() {
       FacilityName = "Aqua Physio",
        Location = new Address() {
         StreetNo = "12",
          Street = "Maitland STREET",
          Suburb = "GEELONG WEST",
          State = "Vic",
          PostCode = "3218"
        }
      },
      PhoneNumber = "03 5221 0555",
      Email = "info@newtownphysio.com.au",
      HoursActive = new List < HoursActive > {
       new HoursActive() {
        WeekDays = "Tuesday",
         Hours = "2pm - 3pm"
       },
       new HoursActive() {
        WeekDays = "Thursday",
         Hours = "2pm - 3pm"
       }
      }
    }
   };
            _context.AddRange(_medicalProfessionaList);
            await _context.SaveChangesAsync();
        }
    }


}
