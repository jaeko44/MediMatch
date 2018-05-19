using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MediMatchRMIT.Models
{
    public class MedicalProfessional
    {
        public MedicalProfessional() {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstMidName { get; set; }
        [Required]
        public string LastName { get; set; }
        //public IList<Service> Services { get; set; } 
        public Service Service { get; set; }
        public Guid ServiceId { get; set; }
        public List<HoursActive> HoursActive { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Review> Reviews { get; set; }
        public Facility Facility { get; set; }
        public Guid FacilityId { get; set; }
        [NotMapped]
        public Image Image {get; set;}
        public string UserId { get; set; }
    }
    public class Image {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath {get; set;}
        public IFormFile  ImageFile {get; set;}
    }
    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }

    }
    public class HoursActive
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string WeekDays { get; set; }
        public string Hours { get; set; }
    }
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public Guid MedicalProfessionalId { get; set; }
        public MedicalProfessional MedicalProfessional { get; set; }
    }
}
