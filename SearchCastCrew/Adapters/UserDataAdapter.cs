using SearchCastCrew.Data;
using SearchCastCrew.Data.Models;
using SearchCastCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
        /***********************************************/
        /*      with search v1.2.2d                    */
        /***********************************************/
namespace SearchCastCrew.Adapters
{
    public class UserDataAdapter : IUserAdapter
    {
        /***********************************************/
        /*      USER FUNCTIONS                         */
        /***********************************************/
        // Grabs all users
        public List<UserVm> GetAllUsers(int num)
        {
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                List<UserVm> myVm = new List<UserVm>();
                myVm = db.Users.Where(u => u.IsDeleted == false).Select(u => new UserVm()
                {
                    UserId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Title = u.Title,
                    City = u.City,
                    State = u.State,
                    Zip = u.Zip,
                    HeightInInches = u.HeightInInches, 
                    HeightConverted = u.HeightInInches / 12 + "' " + u.HeightInInches % 12 + "\"",
                    Weight = u.Weight,
                    AgeRangeId = u.AgeRangeId,
                    AvailabilityId = u.AvailabilityId,
                    BodyTypeId = u.BodyTypeId,
                    EthnicityId = u.EthnicityId,
                    EyeColorId = u.EyeColorId,
                    GenderId = u.GenderId,
                    HairColorId = u.HairColorId,
                    CurrPage = 0,

                    ImageUrl = db.Images.Where(c => c.UserId == u.Id && c.IsProfile == true).Select(p => new ImageVm()
                    {
                        ImgUrl = p.ImageUrl
                    }).FirstOrDefault()
                }).OrderBy(u => u.LastName).Skip(num * 6).Take(6).ToList();

                return myVm;
            }; 
        }

        public int GetAllUserCount()
        {
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                int userCount = db.Users.Where(u => u.IsDeleted == false).Count();

                return userCount;
            }
        }
        public List<UserVm> GetAllUsersAddresses()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<UserVm> myVm = new List<UserVm>();
                myVm = db.Users.Where(u => u.IsDeleted == false).Select(u => new UserVm()
                {
                    UserId = u.Id,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zip = u.Zip,
                    FullAddress = u.Address + " " + u.City + " " + u.State,
                    CurrPage = 0,
                }).ToList();
                //var address = myVm.FirstOrDefault().FullAddress;
                //var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));
                //var request = WebRequest.Create(requestUri);
                //var response = request.GetResponse();
                //var xdoc = XDocument.Load(response.GetResponseStream());
                //var result = xdoc.Element("GeocodeResponse").Element("result");
                //var locationElement = result.Element("geometry").Element("location");
                //var lat = locationElement.Element("lat");
                //var lng = locationElement.Element("lng");
                //myVm
                return myVm;
            };
        }
        // Get all the data for a single table, including 1-to-many data
        public UserProfileVm GetUser(string uid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                UserProfileVm pVm = new UserProfileVm();
                pVm = db.Users.Where(u => u.Id == uid).Select(u => new UserProfileVm()
                {
                    UserId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Title = u.Title,
                    Biography = u.Biography,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zip = u.Zip,
                    IsUnion = u.IsUnion,
                    HeightInInches = u.HeightInInches / 12 + "' " + u.HeightInInches % 12 + "\"",
                    Weight = u.Weight,
                    HairColor = u.HairColor.Color,
                    EyeColor = u.EyeColor.Color,
                    AgeRange = u.AgeRange.Name,
                    Gender = u.Gender.Name,
                    BodyType = u.BodyType.Name,
                    Ethnicity = u.Ethnicity.Name,
                    Available = u.Availability.Name,

                    ProfileImg = u.Images.Where(i => i.UserId == u.Id && i.IsProfile == true).Select(p => new ProfileImageVm() 
                    {
                        ImageUrl = p.ImageUrl
                    }).FirstOrDefault(),

                    ImageUrl = db.Images.Where(i => i.UserId == u.Id && i.IsDeleted == false).Select(p => new ImageVm()
                    {
                        ImageId = p.ImageId,
                        ImgUrl = p.ImageUrl,
                        ImgDesc = p.ImageDesc,
                        IsProfile = p.IsProfile
                    }).ToList(),

                    VideoUrl = db.Videos.Where(v => v.UserId == u.Id && v.IsDeleted == false).Select(p => new VideoVm()
                    {
                        VideoId = p.VideoId,
                        VideoUrl = p.VideoUrl,
                        VideoDesc = p.VideoDesc
                    }).ToList(),

                    ExpEntry = db.Experiences.Where(e => e.UserId == u.Id && e.IsDeleted == false).Select(p => new ExperienceVm()
                    {
                        ExperienceId = p.ExperienceId,
                        ExpEntry = p.Name
                    }).ToList(),

                    LinkUrl = db.Links.Where(l => l.UserId == u.Id && l.IsDeleted == false).Select(p => new LinkVm()
                    {
                        LinkId = p.LinkId,
                        LinkUrl = p.LinkUrl,
                        LinkType = p.LinkType,
                        LinkDesc = p.LinkDesc
                    }).ToList(),

                    Category = db.UserCategories.Where(c => c.UserId == u.Id).Select(p => new CategoryVm()
                    {
                        Title = p.Category.Title
                    }).ToList()

                }).FirstOrDefault();
                return pVm;
            }
        }

        // Returns the user to be deleted
        public UserToDeleteVm UserToDelete(string uid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                UserToDeleteVm dVm = new UserToDeleteVm();

                dVm = db.Users.Where(u => u.Id == uid).Select(p => new UserToDeleteVm() 
                { 
                    UserId = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName
                }).FirstOrDefault();

                return (dVm);
            }
        }

        // Upon deletion, the IsDeleted flag is set to true.  Nothing is actually deleted.
        public void DeleteUser(string uid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser userToDelete = db.Users.FirstOrDefault(u => u.Id == uid);
                userToDelete.IsDeleted = true;
                db.SaveChanges();
            }
        }

        // Returns the user to be edited
        public UserEditVm UserToEdit(string uid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                UserEditVm eVm = new UserEditVm();
                eVm = db.Users.Where(u => u.Id == uid).Select(u => new UserEditVm()
                {
                    UserId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Title = u.Title,
                    Biography = u.Biography,
                    Address = u.Address,
                    City = u.City,
                    State = u.State,
                    Zip = u.Zip,
                    IsUnion = u.IsUnion,
                    HeightInInches = u.HeightInInches,
                    Weight = u.Weight,
                    HairColor = u.HairColor.Color,
                    EyeColor = u.EyeColor.Color,
                    AgeRange = u.AgeRange.Name,
                    Gender = u.Gender.Name,
                    BodyType = u.BodyType.Name,
                    Ethnicity = u.Ethnicity.Name,
                    Available = u.Availability.Name,

                }).FirstOrDefault();
                return eVm;
            }
        }

        // Saves the edits
        public void SaveChangesToUser(UserEditVm user)
        {
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                ApplicationUser userToEdit = db.Users.FirstOrDefault(u => u.Id == user.UserId);
                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;
                userToEdit.Title = user.Title;
                userToEdit.Biography = user.Biography;
                userToEdit.Address = user.Address;
                userToEdit.City = user.City;
                userToEdit.State = user.State;
                userToEdit.Zip = user.Zip;
                userToEdit.IsUnion = user.IsUnion;
                userToEdit.HeightInInches = user.HeightInInches;
                userToEdit.Weight = user.Weight;
                userToEdit.HairColorId = user.HairColorId;
                userToEdit.EyeColorId = user.EyeColorId;
                userToEdit.AgeRangeId = user.AgeRangeId;
                userToEdit.GenderId = user.GenderId;
                userToEdit.BodyTypeId = user.BodyTypeId;
                userToEdit.EthnicityId = user.EthnicityId;
                userToEdit.AvailabilityId = user.AvailabilityId;

                db.SaveChanges();

            }
        }

        /***********************************************/
        /*      VIDEO FUNCTIONS                        */
        /***********************************************/
        // Adds a new video entry
        public void AddVideo(VideoAddVm nVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var videoString = nVm.NewVideo.VideoUrl.Substring(nVm.NewVideo.VideoUrl.LastIndexOf('=') + 1);

                Video videoToAdd = new Video()
                {
                    VideoUrl = videoString,
                    VideoDesc = nVm.NewVideo.VideoDesc,
                    UserId = nVm.NewVideo.UserId,
                    IsDeleted = false
                };

                db.Videos.Add(videoToAdd);
                db.SaveChanges();
            }
        }

        // Returns the video to be deleted
        public VideoToDeleteVm VideoToDelete(int vid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VideoToDeleteVm vVm = new VideoToDeleteVm();

                vVm = db.Videos.Where(v => v.VideoId == vid).Select(p => new VideoToDeleteVm()
                {
                    VideoUrl = p.VideoUrl
                }).FirstOrDefault();

                return (vVm);
            }
        }

        // Deletes a video entry - true deletion
        public void DeleteVideo(int vid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                Video videoToDelete = db.Videos.FirstOrDefault(v => v.VideoId == vid);
                db.Videos.Remove(videoToDelete);
                db.SaveChanges();
            }
        }

        /***********************************************/
        /*      IMAGE FUNCTIONS                        */
        /***********************************************/
        // Add a new image
        public void AddImage(ImageAddVm iVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Images.Add(iVm.NewImage);
                db.SaveChanges();
            }
        }

        // Returns the image to be deleted
        public ImageToDeleteVm ImageToDelete(int imgId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ImageToDeleteVm iVm = new ImageToDeleteVm();

                iVm = db.Images.Where(i => i.ImageId == imgId).Select(p => new ImageToDeleteVm()
                {
                    ImageId = imgId,
                    ImageUrl = p.ImageUrl
                }).FirstOrDefault();

                return (iVm);
            }
        }
        
        // Delete an image
        public void DeleteImage(ImageToDeleteVm ivm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Image imageToDelete = db.Images.FirstOrDefault(i => i.ImageId == ivm.ImageId);
                db.Images.Remove(imageToDelete);
                db.SaveChanges();
            }
        }
        // Grab the image to be edited
        public ImageProfileVm ImageToEdit(int imgId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ImageProfileVm ipVm = new ImageProfileVm();

                Image imgToEdit = db.Images.FirstOrDefault(i => i.ImageId == imgId);
                ipVm.ImageUrl = imgToEdit.ImageUrl;
                ipVm.ImageId = imgToEdit.ImageId;
                ipVm.UserId = imgToEdit.UserId;
                ipVm.IsProfile = imgToEdit.IsProfile;

                return (ipVm);
            }
        }

        //Make it a profile picture
        public void SetProfilePicture(ImageProfileVm ipVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Image> imgList = db.Images.Where(i => i.UserId == ipVm.UserId).ToList();
                foreach (var i in imgList)
                {
                    i.IsProfile = false;
                }

                Image image = db.Images.FirstOrDefault(i => i.ImageId == ipVm.ImageId);
                image.IsProfile = true;
                db.SaveChanges();
            }
        }

        /***********************************************/
        /*      EXPERIENCE FUNCTIONS                   */
        /***********************************************/
        // Add a new Experience entry
        public void AddExperience(ExperienceAddVm eVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Experiences.Add(eVm.NewExperience);
                db.SaveChanges();
            }
        }

        // Return the Experience entry to be edited
        public ExperienceEditVm ExperienceToEdit(int eid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ExperienceEditVm eVm = new ExperienceEditVm();
                eVm = db.Experiences.Where(e => e.ExperienceId == eid).Select(p => new ExperienceEditVm()
                {
                    ExperienceId = eid,
                    Name = p.Name
                }).FirstOrDefault();

                return (eVm);
            }
        }

        // Save ther edits to the Experience entry
        public void SaveChangesToExperience(ExperienceEditVm eVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Experience expToEdit = db.Experiences.FirstOrDefault(e => e.ExperienceId == eVm.ExperienceId);
                expToEdit.ExperienceId = eVm.ExperienceId;
                expToEdit.Name = eVm.Name;
                db.SaveChanges();
            }
        }

        // Returns the Experience entry to be deleted
        public ExperienceToDeleteVm ExperienceToDelete(int eid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ExperienceToDeleteVm eVm = new ExperienceToDeleteVm();

                eVm = db.Experiences.Where(e => e.ExperienceId == eid).Select(p => new ExperienceToDeleteVm()
                {
                    Name = p.Name
                }).FirstOrDefault();

                return (eVm);
            }
        }
        
        // Delete an Experience entry
        public void DeleteExperience(int eid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Experience expToDelete = db.Experiences.FirstOrDefault(e => e.ExperienceId == eid);
                db.Experiences.Remove(expToDelete);
                db.SaveChanges();
            }
        }

        /***********************************************/
        /*      LINK FUNCTIONS                         */
        /***********************************************/
        // Add a new Link entry
        public void AddLink(LinkAddVm lVm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Links.Add(lVm.NewLink);
                db.SaveChanges();
            }
        }

        // Returns the Link entry to be deleted
        public LinkToDeleteVm LinkToDelete(int lid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                LinkToDeleteVm lVm = new LinkToDeleteVm();

                lVm = db.Links.Where(l => l.LinkId == lid).Select(p => new LinkToDeleteVm()
                {
                    LinkUrl = p.LinkUrl,
                    LinkType = p.LinkType
                }).FirstOrDefault();

                return (lVm);
            }
        }

        // Delete a Link entry
        public void DeleteLink(int lid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Link linkToDelete = db.Links.FirstOrDefault(l => l.LinkId == lid);
                db.Links.Remove(linkToDelete);
                db.SaveChanges();
            }
        }

        /***********************************************/
        /*      SEARCH FUNCTIONS                       */
        /***********************************************/
        //public UserIndexVm FilteredUsers(SearchFilterVm svm)
        public SearchFilterVm FilteredUsers(SearchFilterVm svm)       
        {
           //UserIndexVm userResultsVm = new UserIndexVm();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SearchFilterVm finVm = new SearchFilterVm();

                List<UserVm> myVm = new List<UserVm>();
                myVm = db.Users.Where(u => u.IsDeleted == false)                   
                    .Select(u => new UserVm()
                {
                    UserId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Title = u.Title,
                    City = u.City,
                    State = u.State,
                    Zip = u.Zip,
                    HeightInInches = u.HeightInInches,
                    HeightConverted = u.HeightInInches / 12 + "' " + u.HeightInInches % 12 + "\"",
                    Weight = u.Weight,
                    AgeRangeId = u.AgeRangeId,
                    AvailabilityId = u.AvailabilityId,
                    BodyTypeId = u.BodyTypeId,
                    EthnicityId = u.EthnicityId,
                    EyeColorId = u.EyeColorId,
                    GenderId = u.GenderId,
                    HairColorId = u.HairColorId,
                    CurrPage = 0,

                    ImageUrl = db.Images.Where(c => c.UserId == u.Id && c.IsProfile == true).Select(p => new ImageVm()
                    {
                        ImgUrl = p.ImageUrl
                    }).FirstOrDefault()
                }).ToList();

                if (svm.FirstName != null)
                {
                    myVm = myVm.Where(m => m.FirstName == svm.FirstName).ToList();                    
                }

                if (svm.LastName != null)
                {
                    myVm = myVm.Where(m => m.LastName == svm.LastName).ToList();
                }

                if (svm.City != null)
                {
                    myVm = myVm.Where(m => m.City == svm.City).ToList();
                }

                if (svm.State != null)
                {
                    myVm = myVm.Where(m => m.State == svm.State).ToList();
                }

                if (svm.HeightInInches != null)
                {
                    myVm = myVm.Where(m => m.HeightInInches == svm.HeightInInches).ToList();
                }

                if (svm.Weight != null)
                {
                    myVm = myVm.Where(m => m.Weight == svm.Weight).ToList();
                }

                if (svm.HairColorId != null)
                {
                    myVm = myVm.Where(m => m.HairColorId == svm.HairColorId).ToList();
                }

                if (svm.EyeColorId != null)
                {
                    myVm = myVm.Where(m => m.EyeColorId == svm.EyeColorId).ToList();
                }

                if (svm.AgeRangeId != null)
                {
                    myVm = myVm.Where(m => m.AgeRangeId == svm.AgeRangeId).ToList();
                }

                if (svm.GenderId != null)
                {
                    myVm = myVm.Where(m => m.GenderId == svm.GenderId).ToList();
                }

                if (svm.BodyTypeId != null)
                {
                    myVm = myVm.Where(m => m.BodyTypeId == svm.BodyTypeId).ToList();
                }

                if (svm.EthnicityId != null)
                {
                    myVm = myVm.Where(m => m.EthnicityId == svm.EthnicityId).ToList();
                }

                if (svm.AvailabilityId != null)
                {
                    myVm = myVm.Where(m => m.AvailabilityId == svm.AvailabilityId).ToList();
                }

                finVm.TotalUsers = myVm.Count();

                myVm = myVm.OrderBy(u => u.LastName).Skip(svm.CurrPage * 6).Take(6).ToList();

                finVm.UserList = myVm;

               // userResultsVm.UserList = myVm;

                //return (userResultsVm);
                return finVm;
            }

        }
    }
}