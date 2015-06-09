using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchCastCrew.Data.Models;

namespace SearchCastCrew.Models
{
    public class UserProfileVm
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
        public string HeightInInches { get; set; }
        public int Weight { get; set; }
        //public string ProfileImgUrl { get; set; }
        public string HairColor { get; set; } // Foreign lookup table for user's hair color
        public string EyeColor { get; set; } // Foreign lookup table for user's eye color
        public string AgeRange { get; set; } // Foreign lookup table for user's age range
        public string Gender { get; set; } // Foreign lookup table for user's gender
        public string BodyType { get; set; } // Foreign lookup table for user's body type
        public string Ethnicity { get; set; } // Foreign lookup table for user's ethnicity
        public string Available { get; set; } // Foreign lookup table for user's availability
        public bool canEdit { get; set; }//can the user edit profile or not
        public List<ImageVm> ImageUrl { get; set; } // Returns list of images for user
        public List<VideoVm> VideoUrl { get; set; } // Returns list of videos for user
        public List<ExperienceVm> ExpEntry { get; set; } // Returns list of work experience for user
        public List<LinkVm> LinkUrl { get; set; } // Returns list of links for user
        public List<CategoryVm> Category { get; set; } // Returns list of categories for user
        public ProfileImageVm ProfileImg { get; set; } // Returns the user's profile image
    }
}