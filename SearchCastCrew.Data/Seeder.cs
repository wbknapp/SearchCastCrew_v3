using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchCastCrew.Data.Models;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SearchCastCrew.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool seedUsers, bool seedUserData, bool seedSiteUser, bool seedOtherTables)
        {

              RoleStore<Role> roleStore = new RoleStore<Role>(db);
                RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            if (seedUsers)
            {
              

                // Roles....
                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new Role
                    {
                        Name = "Admin"
                    });
                }

                if (!roleManager.RoleExists("General"))
                {
                    roleManager.Create(new Role
                    {
                        Name = "General"
                    });
                }

                ApplicationUser bill = userManager.FindByEmail("v1wikn@gmail.com");

                if (bill == null)
                {
                    bill = new ApplicationUser
                    {
                        
                        Email = "v1wikn@gmail.com",
                        UserName = "v1wikn@gmail.com",
                        FirstName = "Bill",
                        LastName = "Knapp",
                        Title = "SnoopDogg",
                        Address = "411 Elm",
                        City = "Htizzle",
                        State = "Tx",
                        Zip = 123434,
                        IsUnion = false,
                        IsDeleted = false


                    };

                    userManager.Create(bill, "ABC123456!");
                    userManager.AddToRole(bill.Id, "Admin");

                    bill = userManager.FindByEmail("v1wikn@gmail.com");
                }
                else
                {
                    if (!userManager.IsInRole(bill.Id, "Admin"))
                    {
                        userManager.AddToRole(bill.Id, "Admin");
                    }
                }

            }


            if (seedUserData)
            {

                db.HairColors.AddOrUpdate(
                    hc => hc.HairColorId,
                    new HairColor() { HairColorId = 1, Color = "Black" },
                    new HairColor() { HairColorId = 2, Color = "Brown" },
                    new HairColor() { HairColorId = 3, Color = "Blond" },
                    new HairColor() { HairColorId = 4, Color = "Auburn" },
                    new HairColor() { HairColorId = 5, Color = "Chestnut" },
                    new HairColor() { HairColorId = 6, Color = "Red" },
                    new HairColor() { HairColorId = 7, Color = "Gray" },
                    new HairColor() { HairColorId = 8, Color = "White" }
                );

                db.EyeColors.AddOrUpdate(
                    ec => ec.EyeColorId,
                    new EyeColor() { EyeColorId = 1, Color = "Amber" },
                    new EyeColor() { EyeColorId = 2, Color = "Blue" },
                    new EyeColor() { EyeColorId = 3, Color = "Brown" },
                    new EyeColor() { EyeColorId = 4, Color = "Gray" },
                    new EyeColor() { EyeColorId = 5, Color = "Green" },
                    new EyeColor() { EyeColorId = 6, Color = "Hazel" },
                    new EyeColor() { EyeColorId = 7, Color = "Red and Violet" }
                );

                db.Categories.AddOrUpdate(
                    cat => cat.CategoryId,
                    new Category() { CategoryId = 1, Title = "Producer" },
                    new Category() { CategoryId = 2, Title = "Producer Assistant" },
                    new Category() { CategoryId = 3, Title = "Actor" },
                    new Category() { CategoryId = 4, Title = "Makeup Artist" },
                    new Category() { CategoryId = 5, Title = "Production Scout" },
                    new Category() { CategoryId = 6, Title = "Camera Man" },
                    new Category() { CategoryId = 7, Title = "Assistant Director" },
                    new Category() { CategoryId = 8, Title = "Set Manager" },
                    new Category() { CategoryId = 9, Title = "Casting Director" },
                    new Category() { CategoryId = 10, Title = "Craft Services" },
                    new Category() { CategoryId = 11, Title = "Assistant Producer" },
                    new Category() { CategoryId = 12, Title = "Stunt Devil" }
                );

                db.Availability.AddOrUpdate(
                    ava => ava.AvailabilityId,
                    new Availability() { AvailabilityId = 1, Name = "Today" },
                    new Availability() { AvailabilityId = 2, Name = "Tomorrow" },
                    new Availability() { AvailabilityId = 3, Name = "Couple Days From Now" },
                    new Availability() { AvailabilityId = 4, Name = "One Week" },
                    new Availability() { AvailabilityId = 5, Name = "Two Weeks" },
                    new Availability() { AvailabilityId = 6, Name = "One Month" },
                    new Availability() { AvailabilityId = 7, Name = "Couple Months From Now" },
                    new Availability() { AvailabilityId = 7, Name = "Not Available" }
                );

                db.Ethnicities.AddOrUpdate(
                    e => e.EthnicityId,
                    new Ethnicity() { EthnicityId = 1, Name = "African American" },
                    new Ethnicity() { EthnicityId = 2, Name = "American Indian" },
                    new Ethnicity() { EthnicityId = 3, Name = "Caucasian" },
                    new Ethnicity() { EthnicityId = 4, Name = "Mexican American" },
                    new Ethnicity() { EthnicityId = 5, Name = "Hispanic" },
                    new Ethnicity() { EthnicityId = 6, Name = "Asian" },
                    new Ethnicity() { EthnicityId = 7, Name = "Pacific Islander" },
                    new Ethnicity() { EthnicityId = 8, Name = "Multi-Racial" },
                    new Ethnicity() { EthnicityId = 9, Name = "No Response" }
                );

                db.Genders.AddOrUpdate(
                    g => g.GenderId,
                    new Gender() { GenderId = 1, Name = "Male" },
                    new Gender() { GenderId = 2, Name = "Female" },
                    new Gender() { GenderId = 3, Name = "Trans Gender" },
                    new Gender() { GenderId = 4, Name = "No Response" }
                );

                db.BodyTypes.AddOrUpdate(
                    b => b.BodyTypeId,
                    new BodyType() { BodyTypeId = 1, Name = "Athletic" },
                    new BodyType() { BodyTypeId = 2, Name = "Curvy" },
                    new BodyType() { BodyTypeId = 3, Name = "Robust" },
                    new BodyType() { BodyTypeId = 4, Name = "Thin" },
                    new BodyType() { BodyTypeId = 5, Name = "Muscular" }
                );

                db.AgeRanges.AddOrUpdate(
                    b => b.AgeRangeId,
                    new AgeRange() { AgeRangeId = 1, Name = "0-10" },
                    new AgeRange() { AgeRangeId = 2, Name = "11-20" },
                    new AgeRange() { AgeRangeId = 3, Name = "21-30" },
                    new AgeRange() { AgeRangeId = 4, Name = "31-40" },
                    new AgeRange() { AgeRangeId = 5, Name = "41-50" },
                    new AgeRange() { AgeRangeId = 6, Name = "51-60" },
                    new AgeRange() { AgeRangeId = 7, Name = "61-70" },
                    new AgeRange() { AgeRangeId = 8, Name = "71-80" },
                    new AgeRange() { AgeRangeId = 9, Name = "81-90" },
                    new AgeRange() { AgeRangeId = 10, Name = "91-100" }
                );
            }


            if (seedSiteUser)
            {
                
                db.Users.AddOrUpdate(
                    e => e.Email,
                    new ApplicationUser() { FirstName = "Joshua", LastName = "Lerma", Title = "Shift Manager", Address = "666 Sunset Blvd ", City = "Gilmer", State = "Texas", Zip = 75605, Email = "Joshualerma0322@yahoo.com", UserName = "Joshualerma0322@yahoo.com", HeightInInches = 60, Weight = 180, HairColorId = 1, EyeColorId = 1, AgeRangeId = 2, GenderId = 1, BodyTypeId = 1, EthnicityId = 1, AvailabilityId = 2, IsUnion = true, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Michael", LastName = "Lerma", Title = "Taco Maker", Address = "666 Sunset Blvd ", City = "Gilmer", State = "Texas", Zip = 75606, Email = "micahellerma0322@yahoo.com", UserName = "micahellerma0322@yahoo.com", HeightInInches = 66, Weight = 200, HairColorId = 2, EyeColorId = 2, AgeRangeId = 3, GenderId = 1, BodyTypeId = 3, EthnicityId = 2, AvailabilityId = 1, IsUnion = false, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Rebecca", LastName = "Lerma", Title = "Loan Shark", Address = "666 Sunset Blvd ", City = "Gilmer", State = "Texas", Zip = 75607, Email = "Rebecca@yahoo.com", UserName = "Rebecca@yahoo.com", HeightInInches = 56, Weight = 170, HairColorId = 3, EyeColorId = 3, AgeRangeId = 3, GenderId = 2, BodyTypeId = 3, EthnicityId = 2, AvailabilityId = 3, IsUnion = false, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Triston", LastName = "Salazar", Title = "Game Developer", Address = "666 Sunset Blvd ", City = "Longview", State = "Texas", Zip = 75655, Email = "Tristoff2@yahoo.com", UserName = "Tristoff2@yahoo.com", HeightInInches = 80, Weight = 160, HairColorId = 2, EyeColorId = 3, AgeRangeId = 2, GenderId = 1, BodyTypeId = 1, EthnicityId = 1, AvailabilityId = 4, IsUnion = true, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Nabil", LastName = "Clinton", Title = "Loser in Chief", Address = "666 Sunset Blvd ", City = "Henderson", State = "Texas", Zip = 75668, Email = "loser@yahoo.com", UserName = "loser@yahoo.com", HeightInInches = 50, Weight = 250, HairColorId = 2, EyeColorId = 3, AgeRangeId = 2, GenderId = 1, BodyTypeId = 1, EthnicityId = 1, AvailabilityId = 2, IsUnion = true, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Leonarda", LastName = "Lauritzen", Title = "VP of Consulting ", Address = "444 Yankee", City = "Pearland", State = "Texas", Zip = 77581, Email = "LenoardaLauritzen@yahoo.com ", UserName = "LenoardaLauritzen@yahoo.com ", HeightInInches = 60, Weight = 123, HairColorId = 2, EyeColorId = 2, AgeRangeId = 5, GenderId = 1, BodyTypeId = 2, EthnicityId = 3, AvailabilityId = 3, IsUnion = false, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Brenda ", LastName = "Bass ", Title = "Senior Set Design ", Address = "123 Elmwood ", City = "Elgin ", State = "South Carolina ", Zip = 29045, Email = "BrendaBass@yahoo.com ", UserName = "BrendaBass@yahoo.com ", HeightInInches = 60, Weight = 123, HairColorId = 2, EyeColorId = 2, AgeRangeId = 1, GenderId = 2, BodyTypeId = 3, EthnicityId = 2, AvailabilityId = 1, IsUnion = false, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Tom ", LastName = "Collins ", Title = "Junior Set Design ", Address = "123 Dicks Street ", City = "Austin ", State = "Texas ", Zip = 31043, Email = "TomCollins@yahoo.com ", UserName = "TomCollins@yahoo.com ", HeightInInches = 70, Weight = 123, HairColorId = 2, EyeColorId = 2, AgeRangeId = 6, GenderId = 3, BodyTypeId = 2, EthnicityId = 3, AvailabilityId = 1, IsUnion = true, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Bobby ", LastName = "Rick ", Title = "Baby Jesus ", Address = "666 YourFace Street ", City = "Atlanta", State = "Georgia", Zip = 30032, Email = "BobbyRick@yahoo.com ", UserName = "BobbyRick@yahoo.com ", HeightInInches = 75, Weight = 123, HairColorId = 1, EyeColorId = 4, AgeRangeId = 5, GenderId = 2, BodyTypeId = 2, EthnicityId = 3, AvailabilityId = 1, IsUnion = false, IsDeleted = false },
                    new ApplicationUser() { FirstName = "Naomi", LastName = "Watts", Title = "MyMainB", Address = "777 Sunset Blvd ", City = "Hollywood", State = "California", Zip = 90069, IsUnion = false, IsDeleted = false, HeightInInches = 75, Weight = 123, Email = "NaomiWatts@hotmail.com", UserName = "NaomiWatts@hotmail.com", PhoneNumber = "123456", HairColorId = 3, EyeColorId = 2, AgeRangeId = 4, GenderId = 2, BodyTypeId = 1, EthnicityId = 3, AvailabilityId = 1 }
                );
            }

            if (seedOtherTables)
            {
                ApplicationUser user1 = userManager.FindByEmail("Joshualerma0322@yahoo.com");

                if (user1 != null){

               

                //ApplicationUser Joshua = userManager.FindByEmail("Joshualerma0322@yahoo.com");
                //ApplicationUser Michael = userManager.FindByEmail("micahellerma0322@yahoo.com");
                //ApplicationUser Rebecca = userManager.FindByEmail("Rebecca@yahoo.com");
                //ApplicationUser Triston = userManager.FindByEmail("Tristoff2@yahoo.com");
                //ApplicationUser Nabil = userManager.FindByEmail("loser@yahoo.com");
                //ApplicationUser Brenda = userManager.FindByEmail("BrendaBass@yahoo.com");
                //ApplicationUser Tom = userManager.FindByEmail("TomCollins@yahoo.com");
                //ApplicationUser Naomi = userManager.FindByEmail("NaomiWatts@hotmail.com");

                db.Links.AddOrUpdate(
                    l => l.LinkId,
                        new Link() { UserId = user1.Id, IsDeleted = false, LinkUrl = "https://www.facebook.com/", LinkType = "Facebook" },
                        new Link() { UserId = user1.Id, IsDeleted = false, LinkUrl = "https://twitter.com/", LinkType = "Twitter" },
                        new Link() { UserId = user1.Id, IsDeleted = false, LinkUrl = "https://www.linkedin.com/", LinkType = "Linkedin" },
                        new Link() { UserId = user1.Id, IsDeleted = false, LinkUrl = "http://www.ign.com/", LinkType = "Web" }
                    );

                db.Images.AddOrUpdate(
                    img => img.ImageId,
                        new Image() { UserId = user1.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://png-2.findicons.com/files/icons/2052/social_network/32/facebook.png", ImageDesc = "Pic of Facebook Icon" },
                        new Image() { UserId = user1.Id, IsDeleted = false, IsProfile = false, ImageUrl = "https://www.microsoft.com/en-us/outlook-com/img/footer-icon-twitter.5919eab4.svg", ImageDesc = "Pic of Twitter Icon" },
                        new Image() { UserId = user1.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://www.alvincollege.edu/Portals/0/instagram.png", ImageDesc = "Pic of Instagram Icon" }
                    );

                db.Videos.AddOrUpdate(
                    vid => vid.VideoId,
                    new Video() { UserId = user1.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/theofficialfacebook", VideoDesc = "FaceBook Youtube Page" },
                    new Video() { UserId = user1.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/Twitter", VideoDesc = "Twitter Youtube Page" },
                    new Video() { UserId = user1.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/LinkedIn", VideoDesc = "Linkedin Youtube Page" }
                    );

                db.Experiences.AddOrUpdate(
                    exp => exp.ExperienceId,
                    new Experience() { UserId = user1.Id, IsDeleted = false, Name = "I have break-dancing experience."},
                    new Experience() { UserId = user1.Id, IsDeleted = false, Name = "I have experience in karate movies."}
                    );

                db.UserCategories.AddOrUpdate(
                    uc => uc.UserCategoryId,
                    new UserCategory() { UserId = user1.Id, UserCategoryId = 1, CategoryId = 2 },
                    new UserCategory() { UserId = user1.Id, UserCategoryId = 2, CategoryId = 5 },
                    new UserCategory() { UserId = user1.Id, UserCategoryId = 3, CategoryId = 4 },
                    new UserCategory() { UserId = user1.Id, UserCategoryId = 4, CategoryId = 6 }
                    );

                if (seedOtherTables)
                {
                    ApplicationUser user2 = userManager.FindByEmail("micahellerma0322@yahoo.com");

                    if (user2 != null)
                    {

                        db.Links.AddOrUpdate(
                        l => l.LinkId,
                            new Link() { UserId = user2.Id, IsDeleted = false, LinkUrl = "https://www.facebook.com/", LinkType = "Facebook" },
                            new Link() { UserId = user2.Id, IsDeleted = false, LinkUrl = "https://twitter.com/", LinkType = "Twitter" },
                            new Link() { UserId = user2.Id, IsDeleted = false, LinkUrl = "https://instagram.com/", LinkType = "Instagram" },
                            new Link() { UserId = user2.Id, IsDeleted = false, LinkUrl = "https://www.thumbtack.com/tx/pearland/makeup-artists/", LinkType = "Web" }
                        );

                        db.Images.AddOrUpdate(
                            img => img.ImageId,
                                new Image() { UserId = user2.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://png-2.findicons.com/files/icons/2052/social_network/32/facebook.png", ImageDesc = "Pic of Facebook Icon" },
                                new Image() { UserId = user2.Id, IsDeleted = false, IsProfile = false, ImageUrl = "https://www.microsoft.com/en-us/outlook-com/img/footer-icon-twitter.5919eab4.svg", ImageDesc = "Pic of Twitter Icon" },
                                new Image() { UserId = user2.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://www.alvincollege.edu/Portals/0/instagram.png", ImageDesc = "Pic of Instagram Icon" }
                            );

                        db.Videos.AddOrUpdate(
                            vid => vid.VideoId,
                            new Video() { UserId = user2.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/theofficialfacebook", VideoDesc = "FaceBook Youtube Page" },
                            new Video() { UserId = user2.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/Twitter", VideoDesc = "Twitter Youtube Page" },
                            new Video() { UserId = user2.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/", VideoDesc = "Youtube Page" }
                            );

                        db.Experiences.AddOrUpdate(
                            exp => exp.ExperienceId,
                            new Experience() { UserId = user2.Id, IsDeleted = false, Name = "I have experience in doing make-up." },
                            new Experience() { UserId = user2.Id, IsDeleted = false, Name = "I have experience in building sets for movies." },
                            new Experience() { UserId = user2.Id, IsDeleted = false, Name = "I have experience in producing a film." }
                            );

                        db.UserCategories.AddOrUpdate(
                            uc => uc.UserCategoryId,
                            new UserCategory() { UserId = user2.Id, UserCategoryId = 1, CategoryId = 4 },
                            new UserCategory() { UserId = user2.Id, UserCategoryId = 2, CategoryId = 1 },
                            new UserCategory() { UserId = user2.Id, UserCategoryId = 3, CategoryId = 7 },
                            new UserCategory() { UserId = user2.Id, UserCategoryId = 4, CategoryId = 10 }
                            );
                    }
                }

                if (seedOtherTables)
                {
                    ApplicationUser user3 = userManager.FindByEmail("TomCollins@yahoo.com");

                    if (user3 != null)
                    {

                        db.Links.AddOrUpdate(
                        l => l.LinkId,
                            new Link() { UserId = user3.Id, IsDeleted = false, LinkUrl = "https://www.facebook.com/", LinkType = "Facebook" },
                            new Link() { UserId = user3.Id, IsDeleted = false, LinkUrl = "https://twitter.com/", LinkType = "Twitter" },
                            new Link() { UserId = user3.Id, IsDeleted = false, LinkUrl = "https://instagram.com/", LinkType = "Instagram" },
                            new Link() { UserId = user3.Id, IsDeleted = false, LinkUrl = "http://stuntsunlimited.com/", LinkType = "Web" }
                        );

                        db.Images.AddOrUpdate(
                            img => img.ImageId,
                                new Image() { UserId = user3.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://png-2.findicons.com/files/icons/2052/social_network/32/facebook.png", ImageDesc = "Pic of Facebook Icon" },
                                new Image() { UserId = user3.Id, IsDeleted = false, IsProfile = false, ImageUrl = "https://www.microsoft.com/en-us/outlook-com/img/footer-icon-twitter.5919eab4.svg", ImageDesc = "Pic of Twitter Icon" },
                                new Image() { UserId = user3.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://www.alvincollege.edu/Portals/0/instagram.png", ImageDesc = "Pic of Instagram Icon" }
                            );

                        db.Videos.AddOrUpdate(
                            vid => vid.VideoId,
                            new Video() { UserId = user3.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/theofficialfacebook", VideoDesc = "FaceBook Youtube Page" },
                            new Video() { UserId = user3.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/Twitter", VideoDesc = "Twitter Youtube Page" },
                            new Video() { UserId = user3.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/watch?v=LHmPq4KkX9M/", VideoDesc = "Youtube Page on Stunts" }
                            );

                        db.Experiences.AddOrUpdate(
                            exp => exp.ExperienceId,
                            new Experience() { UserId = user3.Id, IsDeleted = false, Name = "I have experience doing stunts." },
                            new Experience() { UserId = user3.Id, IsDeleted = false, Name = "I have experience setting up tech stuffs." },
                            new Experience() { UserId = user3.Id, IsDeleted = false, Name = "I have experience in handling props." }
                            );

                        db.UserCategories.AddOrUpdate(
                            uc => uc.UserCategoryId,
                            new UserCategory() { UserId = user3.Id, UserCategoryId = 1, CategoryId = 6},
                            new UserCategory() { UserId = user3.Id, UserCategoryId = 2, CategoryId = 8 },
                            new UserCategory() { UserId = user3.Id, UserCategoryId = 3, CategoryId = 9 },
                            new UserCategory() { UserId = user3.Id, UserCategoryId = 4, CategoryId = 12 }
                            );
                    }
                }

                if (seedOtherTables)
                {
                    ApplicationUser user4 = userManager.FindByEmail("NaomiWatts@hotmail.com");

                    if (user4 != null)
                    {

                        db.Links.AddOrUpdate(
                        l => l.LinkId,
                            new Link() { UserId = user4.Id, IsDeleted = false, LinkUrl = "https://www.facebook.com/", LinkType = "Facebook" },
                            new Link() { UserId = user4.Id, IsDeleted = false, LinkUrl = "https://twitter.com/", LinkType = "Twitter" },
                            new Link() { UserId = user4.Id, IsDeleted = false, LinkUrl = "https://instagram.com/", LinkType = "Instagram" },
                            new Link() { UserId = user4.Id, IsDeleted = false, LinkUrl = "http://www.biography.com/people/groups/filmmakers-producers", LinkType = "Web" }
                        );

                        db.Images.AddOrUpdate(
                            img => img.ImageId,
                                new Image() { UserId = user4.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://png-2.findicons.com/files/icons/2052/social_network/32/facebook.png", ImageDesc = "Pic of Facebook Icon" },
                                new Image() { UserId = user4.Id, IsDeleted = false, IsProfile = false, ImageUrl = "https://www.microsoft.com/en-us/outlook-com/img/footer-icon-twitter.5919eab4.svg", ImageDesc = "Pic of Twitter Icon" },
                                new Image() { UserId = user4.Id, IsDeleted = false, IsProfile = false, ImageUrl = "http://www.alvincollege.edu/Portals/0/instagram.png", ImageDesc = "Pic of Instagram Icon" }
                            );

                        db.Videos.AddOrUpdate(
                            vid => vid.VideoId,
                            new Video() { UserId = user4.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/theofficialfacebook", VideoDesc = "FaceBook Youtube Page" },
                            new Video() { UserId = user4.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/user/Twitter", VideoDesc = "Twitter Youtube Page" },
                            new Video() { UserId = user4.Id, IsDeleted = false, VideoUrl = "https://www.youtube.com/watch?v=5WyWkacDrxs", VideoDesc = "Youtube Page for Film Producer" }
                            );

                        db.Experiences.AddOrUpdate(
                            exp => exp.ExperienceId,
                            new Experience() { UserId = user4.Id, IsDeleted = false, Name = "I have experience producing major films." },
                            new Experience() { UserId = user4.Id, IsDeleted = false, Name = "I have experience acting." },
                            new Experience() { UserId = user4.Id, IsDeleted = false, Name = "I have experience as a cameraman." }
                            );

                        db.UserCategories.AddOrUpdate(
                            uc => uc.UserCategoryId,
                            new UserCategory() { UserId = user4.Id, UserCategoryId = 1, CategoryId = 1 },
                            new UserCategory() { UserId = user4.Id, UserCategoryId = 2, CategoryId = 3 },
                            new UserCategory() { UserId = user4.Id, UserCategoryId = 3, CategoryId = 6 },
                            new UserCategory() { UserId = user4.Id, UserCategoryId = 4, CategoryId = 11 }
                            );
                    }
                }
                }
            }

        }
    }
}
