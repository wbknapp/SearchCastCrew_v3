using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SearchCastCrew.Data;
using SearchCastCrew.Data.Models;

namespace SearchCastCrew.Controllers
{
    public class CCuserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CCuser
        public ActionResult Index()
        {
            var applicationUsers = db.Users.Include(a => a.AgeRange).Include(a => a.Availability).Include(a => a.BodyType).Include(a => a.Ethnicity).Include(a => a.EyeColor).Include(a => a.Gender).Include(a => a.HairColor);
            return View(applicationUsers.ToList());
        }

        // GET: CCuser/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: CCuser/Create
        public ActionResult Create()
        {
            ViewBag.AgeRangeId = new SelectList(db.AgeRanges, "AgeRangeId", "Name");
            ViewBag.AvailabilityId = new SelectList(db.Availability, "AvailabilityId", "Name");
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "BodyTypeId", "Name");
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Name");
            ViewBag.EyeColorId = new SelectList(db.EyeColors, "EyeColorId", "Color");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Name");
            ViewBag.HairColorId = new SelectList(db.HairColors, "HairColorId", "Color");
            return View();
        }

        // POST: CCuser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Title,Biography,Address,City,State,Zip,IsUnion,IsDeleted,HeightInInches,Weight,HairColorId,EyeColorId,AgeRangeId,GenderId,BodyTypeId,EthnicityId,AvailabilityId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgeRangeId = new SelectList(db.AgeRanges, "AgeRangeId", "Name", applicationUser.AgeRangeId);
            ViewBag.AvailabilityId = new SelectList(db.Availability, "AvailabilityId", "Name", applicationUser.AvailabilityId);
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "BodyTypeId", "Name", applicationUser.BodyTypeId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Name", applicationUser.EthnicityId);
            ViewBag.EyeColorId = new SelectList(db.EyeColors, "EyeColorId", "Color", applicationUser.EyeColorId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Name", applicationUser.GenderId);
            ViewBag.HairColorId = new SelectList(db.HairColors, "HairColorId", "Color", applicationUser.HairColorId);
            return View(applicationUser);
        }

        // GET: CCuser/Edit/5
        public ActionResult Edit(string uid)
        {
            if (uid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(uid);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgeRangeId = new SelectList(db.AgeRanges, "AgeRangeId", "Name", applicationUser.AgeRangeId);
            ViewBag.AvailabilityId = new SelectList(db.Availability, "AvailabilityId", "Name", applicationUser.AvailabilityId);
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "BodyTypeId", "Name", applicationUser.BodyTypeId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Name", applicationUser.EthnicityId);
            ViewBag.EyeColorId = new SelectList(db.EyeColors, "EyeColorId", "Color", applicationUser.EyeColorId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Name", applicationUser.GenderId);
            ViewBag.HairColorId = new SelectList(db.HairColors, "HairColorId", "Color", applicationUser.HairColorId);
            return View(applicationUser);
        }

        // POST: CCuser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Title,Biography,Address,City,State,Zip,IsUnion,IsDeleted,HeightInInches,Weight,HairColorId,EyeColorId,AgeRangeId,GenderId,BodyTypeId,EthnicityId,AvailabilityId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
            }
            ViewBag.AgeRangeId = new SelectList(db.AgeRanges, "AgeRangeId", "Name", applicationUser.AgeRangeId);
            ViewBag.AvailabilityId = new SelectList(db.Availability, "AvailabilityId", "Name", applicationUser.AvailabilityId);
            ViewBag.BodyTypeId = new SelectList(db.BodyTypes, "BodyTypeId", "Name", applicationUser.BodyTypeId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Name", applicationUser.EthnicityId);
            ViewBag.EyeColorId = new SelectList(db.EyeColors, "EyeColorId", "Color", applicationUser.EyeColorId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Name", applicationUser.GenderId);
            ViewBag.HairColorId = new SelectList(db.HairColors, "HairColorId", "Color", applicationUser.HairColorId);
            return View(applicationUser);
        }

        // GET: CCuser/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: CCuser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
