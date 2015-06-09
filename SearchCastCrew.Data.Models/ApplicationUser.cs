using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Data.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Biography { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int Zip { get; set; }
        [Display(Name = "Union Affiliated")]
        public bool IsUnion { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Height")]
        public int HeightInInches { get; set; }
        public int Weight { get; set; }
        // FK to HairColor table
        [Display(Name = "Hair Color")]
        public int? HairColorId { get; set; }
        public virtual HairColor HairColor { get; set; }
        // FK to EyeColor table
        [Display(Name = "Eye Color")]
        public int? EyeColorId { get; set; }
        public virtual EyeColor EyeColor { get; set; }
        // FK to AgeRange table
        [Display(Name = "Age Range")]
        public int? AgeRangeId { get; set; }
        public virtual AgeRange AgeRange { get; set; }
        // FK to Gender table
        [Display(Name = "Gender")]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        // FK to BodyType table
        [Display(Name = "Body Type")]
        public int? BodyTypeId { get; set; }
        public virtual BodyType BodyType { get; set; }
        // FK to Ethnicity table
        [Display(Name = "Ethnicity")]
        public int? EthnicityId { get; set; }
        public virtual Ethnicity Ethnicity { get; set; }
        // FK to Availability table
        [Display(Name = "Availability")]
        public int? AvailabilityId { get; set; }
        public virtual Availability Availability { get; set; }

        // one to many....
        public virtual List<Link> Links { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual List<Video> Videos { get; set; }
        public virtual List<Experience> Experiences { get; set; }

        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
