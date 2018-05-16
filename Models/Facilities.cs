using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace MediMatchRMIT.Models
{
    public class Facility
    {
        public Facility()
        {

        }
        public void SetCoordinates()
        {
            try
            {
                var address = $"{Location.StreetNo} {Location.Street}, {Location.Suburb} , {Location.State} {Location.PostCode}";
                string apiKey = "AIzaSyBkkj6qQ0qLfTGHYJPuL9asFAAk9hlguJ4";
                var locationService = new GoogleLocationService(apiKey);
                var point = locationService.GetLatLongFromAddress(address);

                Location.Coordinates = new DecimalDegrees() {
                    Id = Guid.NewGuid(),
                    Latitude = point.Latitude,
                    Longitude = point.Longitude
                };
                Console.WriteLine($"GET (Coordinates) {Location.Coordinates.Latitude} & {Location.Coordinates.Longitude} of facility: {FacilityName}");
                Debug.WriteLine($"GET (Coordinates) {Location.Coordinates.Latitude} & {Location.Coordinates.Longitude} of facility: {FacilityName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Debug.WriteLine("Error: " + ex);
            }
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FacilityName { get; set; }
        [Required]
        public Address Location { get; set; }
        //Foreign Key for Location
        public Guid LocationId { get; set; }
        public string Website { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        //public ICollection<MedicalProfessional> MedicalProfessionals { get; set; }
        public ICollection<FacilitySupport> FacilitySupport { get; set; }
        public string notes { get; set; }
    }
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string PostCode { get; set; }
        [Required]
        public string Street { get; set; }
        public string State { get; set; }
        public string StreetNo { get; set; }
        public string Suburb { get; set; }
        public DecimalDegrees Coordinates { get; set; }
    }
    public class DecimalDegrees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
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
