using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediMatchRMIT.Models
{
    public class MedicalProfessional
    {
        public int MedicalId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Address { get; set; }
        public virtual HoursActive ServiceActive { get; set; }

        public string Notes { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> MainCategory { get; set; }
        public List<string> SubCategory { get; set; }

        public List<string> Facilities { get; set; }

        public Reviews Feedback { get; set; }

    }

    public class HoursActive
    {
        public List<string> WeekDays { get; set; }
        public List<string> Hours { get; set; }
    }
    public class Reviews
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
    }
}
