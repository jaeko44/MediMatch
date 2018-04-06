﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediMatchRMIT.Models
{
    public class Facility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FacilityName { get; set; }
        [Required]
        public Address Location { get; set; }
        public string Website { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public List<MedicalProfessional> MedicalProfessionals { get; set; }
        public List<FacilitySupport> FacilitySupport { get; set; }
    }
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string PostCode { get; set; }
        [Required]
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string Suburb { get; set; }
        public DecimalDegrees Coordinates { get; set; }
        public Facility Facility { get; set; }
        public Guid FacilityId { get; set; }

    }
    public class DecimalDegrees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
    public class FacilitySupport {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string SupportName { get; set; }
        public string SupportDescription { get; set; }
        public Facility Facility { get; set; }
        public Guid FacilityId { get; set; }
    }
}
