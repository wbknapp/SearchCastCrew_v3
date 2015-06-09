using Microsoft.AspNet.Identity.EntityFramework;
using SearchCastCrew.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SearchCastCrew.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SearchCastCrewConnectionv3", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<AgeRange> AgeRanges { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<EyeColor> EyeColors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HairColor> HairColors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }

        
    }
}
