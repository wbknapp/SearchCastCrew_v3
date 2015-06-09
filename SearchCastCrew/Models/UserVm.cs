using SearchCastCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCastCrew.Models
{
    public class UserVm
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string FullAddress { get; set; }
        public int? HeightInInches { get; set; }
        public string HeightConverted { get; set; }
        public int? Weight { get; set; }
        public int? HairColorId { get; set; }
        public int? EyeColorId { get; set; }
        public int? AgeRangeId { get; set; }
        public int? GenderId { get; set; }
        public int? BodyTypeId { get; set; }
        public int? EthnicityId { get; set; }
        public int? AvailabilityId { get; set; }
        public int CurrPage { get; set; }
        public ImageVm ImageUrl { get; set; }

    }
}