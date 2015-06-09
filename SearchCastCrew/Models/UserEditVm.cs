using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCastCrew.Models
{
    public class UserEditVm
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Biography { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public bool IsUnion { get; set; }
        public int HeightInInches { get; set; }
        public int Weight { get; set; }
        // Foreign lookup table for user's hair color
        public int HairColorId { get; set; }
        public string HairColor { get; set; }
        // Foreign lookup table for user's eye color
        public int EyeColorId { get; set; }
        public string EyeColor { get; set; }
        // Foreign lookup table for user's age range
        public int AgeRangeId { get; set; }
        public string AgeRange { get; set; }
        // Foreign lookup table for user's gender
        public int GenderId { get; set; }
        public string Gender { get; set; }
        // Foreign lookup table for user's body type
        public int BodyTypeId { get; set; }
        public string BodyType { get; set; }
        // Foreign lookup table for user's ethnicity
        public int EthnicityId { get; set; }
        public string Ethnicity { get; set; }
        // Foreign lookup table for user's availability
        public int AvailabilityId { get; set; }
        public string Available { get; set; } 
    }
}