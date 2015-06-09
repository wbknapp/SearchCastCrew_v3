using SearchCastCrew.Adapters;
using SearchCastCrew.Data;
using SearchCastCrew.Data.Models;
using SearchCastCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SearchCastCrew.Controllers
{
    public class ProfilesController : Controller
    {
        //Move to adapter...
        private ApplicationDbContext db = new ApplicationDbContext();
        IUserAdapter _adapter;

        public ProfilesController()
        {
            _adapter = new UserDataAdapter();
        }

        public ProfilesController(IUserAdapter adp)
        {
            _adapter = adp;
        }



        public ActionResult SearchMap()
        {
            UserIndexVm uVm = new UserIndexVm();
            uVm.UserList = _adapter.GetAllUsersAddresses();

            //string[] addArray;
            return View(uVm);

            //UserIndexVm uvm = new UserIndexVm();
            //uvm.UserList.

            //var applicationUsers = db.Users.Include(a => a.AgeRange).Include(a => a.Availability).Include(a => a.BodyType).Include(a => a.Ethnicity).Include(a => a.EyeColor).Include(a => a.Gender).Include(a => a.HairColor);
            //return View(applicationUsers.ToList());
        }


        [HttpGet]
        public ActionResult Search(int num)
        {
            SearchFilterVm svm = new SearchFilterVm();

            svm.UserList = _adapter.GetAllUsers(num);

            svm.TotalUsers = _adapter.GetAllUserCount();
            svm.UsersPerPage = 6;
            svm.PageCount = svm.TotalUsers / svm.UsersPerPage;

            if ((svm.TotalUsers % svm.UsersPerPage) != 0)
            {
                svm.PageCount++;
            }

            // Set the value of PrevPage
            if (num == 0)
            {
                svm.PrevPage = 0;
            }
            else
            {
                svm.PrevPage = num - 1;
            }

            // Set the value of NextPage
            if (num == svm.PageCount - 1)
            {
                svm.NextPage = num;
            }
            else
            {
                svm.NextPage = num + 1;
            }


            //svm.FirstName = "David";
            //svm.LastName = "Graham";
            //svm.City = "houston";
            //svm.State = "TX";
            //svm.Title = "Producer";
            svm.AgeRangeList = new SelectList(db.AgeRanges, "AgeRangeId", "Name");
            svm.AvailabilityList = new SelectList(db.Availability, "AvailabilityId", "Name");
            svm.BodyTypeList = new SelectList(db.BodyTypes, "BodyTypeId", "Name");
            svm.EthnicityList = new SelectList(db.Ethnicities, "EthnicityId", "Name");
            svm.EyeColorList = new SelectList(db.EyeColors, "EyeColorId", "Color");
            svm.GenderList = new SelectList(db.Genders, "GenderId", "Name");
            svm.HairColorList = new SelectList(db.HairColors, "HairColorId", "Color");
            return View(svm);
        }

        /////

        [HttpPost]
        public ActionResult Search(SearchFilterVm svm)
        {

            SearchFilterVm srvm = new SearchFilterVm();

            srvm = _adapter.FilteredUsers(svm);

            srvm.InSearchMode = true;


            srvm.UsersPerPage = 6;
            srvm.PageCount = srvm.TotalUsers / srvm.UsersPerPage;

            if ((srvm.TotalUsers % srvm.UsersPerPage) != 0)
            {
                srvm.PageCount++;
            }

            if (svm.InDirection == "next")
            {
                if (srvm.CurrPage != srvm.PageCount)
                {
                    srvm.CurrPage = srvm.CurrPage;
                }
                else
                {
                    srvm.CurrPage++;
                }
            }

            if (svm.InDirection == "prev")
            {
                if (srvm.CurrPage != 0)
                {
                    srvm.CurrPage--;
                }
            }

            // Set the value of PrevPage
            if (srvm.CurrPage == 0)
            {
                srvm.PrevPage = 0;
            }
            else
            {
                srvm.PrevPage = srvm.CurrPage - 1;
            }

            // Set the value of NextPage
            if (srvm.CurrPage == svm.PageCount - 1)
            {
                srvm.NextPage = srvm.CurrPage;
            }
            else
            {
                srvm.NextPage = srvm.CurrPage + 1;
            }

            srvm.AgeRangeList = new SelectList(db.AgeRanges.ToList(), "AgeRangeId", "Name", svm.AgeRangeId);
            srvm.AvailabilityList = new SelectList(db.Availability.ToList(), "AvailabilityId", "Name", svm.AvailabilityId);
            srvm.BodyTypeList = new SelectList(db.BodyTypes.ToList(), "BodyTypeId", "Name", svm.BodyTypeId);
            srvm.EthnicityList = new SelectList(db.Ethnicities.ToList(), "EthnicityId", "Name", svm.EthnicityId);
            srvm.EyeColorList = new SelectList(db.EyeColors.ToList(), "EyeColorId", "Color", svm.EyeColorId);
            srvm.GenderList = new SelectList(db.Genders.ToList(), "GenderId", "Name", svm.GenderId);
            srvm.HairColorList = new SelectList(db.HairColors.ToList(), "HairColorId", "Color", svm.HairColorId);

            return View(srvm);

        }

        ///
    }
}