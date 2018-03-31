using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediMatchRMIT.Models
{
    public class MedicalProfessional
    {
        [Key]
        public int MedicalId { get; set; }
        public string FacilityName { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public Address Location { get; set; }
        public HoursActive ServiceActive { get; set; }
        public string Notes { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Service> Services { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<Reviews> Feedback { get; set; }

    }
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceType { get; set; }
    }
    public class Facility
    {
        [Key]
        public int ServiceId { get; set; }
        public string Support { get; set; }
    }
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int PostCode { get; set; }
        public int Street { get; set; }
        public int StreetNo { get; set; }
        public string Suburb { get; set; }
        public virtual DecimalDegrees Coordinates { get; set; }
    }
    public class DecimalDegrees
    {
        [Key]
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
    }
    public class HoursActive
    {
        [Key]
        public int ActiveId { get; set; }
        public string WeekDays { get; set; }
        public string Hours { get; set; }
    }
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
    }
}
