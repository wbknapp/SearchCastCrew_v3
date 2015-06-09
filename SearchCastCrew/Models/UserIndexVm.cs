using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchCastCrew.Data.Models;

namespace SearchCastCrew.Models
{
    public class UserIndexVm
    {
        public List<UserVm> UserList { get; set; }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string FullAddress { get; set; }
        public string HeightInInches { get; set; }
        public int Weight { get; set; }
        public int? HairColorId { get; set; }
        public int? EyeColorId { get; set; }
        public int? AgeRangeId { get; set; }
        public int? GenderId { get; set; }
        public int? BodyTypeId { get; set; }
        public int? EthnicityId { get; set; }
        public int? AvailabilityId { get; set; }
        public int CurrPage { get; set; }

    }
}