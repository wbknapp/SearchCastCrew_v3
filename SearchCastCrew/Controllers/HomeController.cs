using Microsoft.AspNet.Identity;
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
    public class HomeController : Controller
    {
        //var for wether user can edit or not
        bool canEdit = false;

        IUserAdapter _adapter;

        public HomeController()
        {
            _adapter = new UserDataAdapter();
        }

        public HomeController(IUserAdapter adp)
        {
            _adapter = adp;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProfile(string uid)
        {
            UserProfileVm pVm = new UserProfileVm();
             pVm = _adapter.GetUser(uid);
            if(User.Identity.GetUserId() == pVm.UserId || User.IsInRole("Admin"))
            {
                canEdit = true;
                pVm.canEdit = canEdit;
            }
           

            return View(pVm);
        }

        public ActionResult Delete(string uid)
        {
            UserToDeleteVm dVm = new UserToDeleteVm();

            if (uid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            dVm = _adapter.UserToDelete(uid);

            if (dVm == null)
            {
                return HttpNotFound();
            }
            return View(dVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string uid)
        {
            _adapter.DeleteUser(uid);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string uid)
        {
            UserEditVm eVm = new UserEditVm();

            eVm = _adapter.UserToEdit(uid);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ViewBag.AgeRangeId = new SelectList(db.AgeRanges, "AgeRangeId", "Name", eVm.AgeRangeId);
                ViewBag.AvailabilityId = new SelectList(db.Availability, "AvailabilityId", "Name", eVm.AvailabilityId);
                ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "BodyTypeId", "Name", eVm.BodyTypeId);
                ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Name", eVm.EthnicityId);
                ViewBag.EyeColorId = new SelectList(db.EyeColors, "EyeColorId", "Color", eVm.EyeColorId);
                ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Name", eVm.GenderId);
                ViewBag.HairColorId = new SelectList(db.HairColors, "HairColorId", "Color", eVm.HairColorId);
            }
            return View(eVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditVm user)
        {
            if (ModelState.IsValid)
            {
                _adapter.SaveChangesToUser(user);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //public ActionResult Search(UserIndexVm uVm)
        //{
        //    UserIndexVm userResultsVm = new UserIndexVm();

        //    if (uVm == null)
        //    {
        //        userResultsVm.UserList = _adapter.GetAllUsers();

        //        return View(userResultsVm);
        //    }
        //    else
        //    {
        //        userResultsVm = _adapter.FilteredUsers(uVm);

        //        return View(userResultsVm);
        //    }
        //}


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}