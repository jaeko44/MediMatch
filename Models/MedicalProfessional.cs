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
        public Guid Id { get; set; }
        [Required]
        public string FirstMidName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ServiceCategory { get; set; }
        //Foreign key for Facility
        //[ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public List<HoursActive> HoursActive { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Reviews> Feedback { get; set; }

    }
    public class HoursActive
    {
        [Key]
        public Guid Id { get; set; }
        public string WeekDays { get; set; }
        public string Hours { get; set; }
    }
    public class Reviews
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
    }
}
