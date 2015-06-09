using SearchCastCrew.Adapters;
using SearchCastCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;

namespace SearchCastCrew.Controllers
{
    public class ExperienceController : Controller
    {
        IUserAdapter _adapter;

        public ExperienceController()
        {
            _adapter = new UserDataAdapter();
        }

        public ExperienceController(IUserAdapter adp)
        {
            _adapter = adp;
        }

        // GET: Experience
        public ActionResult Index()
        {
            return View();
        }

        // Add an Experience entry
        public ActionResult AddExperience()
        {
            ExperienceAddVm eVm = new ExperienceAddVm();

            return View(eVm);
        }

        [HttpPost]
        public ActionResult AddExperience(ExperienceAddVm eVm)
        {
            eVm.NewExperience.UserId = User.Identity.GetUserId();
            _adapter.AddExperience(eVm);

            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }

        // Edit an Experience entry
        public ActionResult EditExperience(int eid)
        {
            ExperienceEditVm edVm = new ExperienceEditVm();

            edVm = _adapter.ExperienceToEdit(eid);

            return View(edVm);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditExperience(ExperienceEditVm edVm)
        {
            _adapter.SaveChangesToExperience(edVm);

            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }

        // Delete an Experience entry
        public ActionResult DeleteExperience(int eid)
        {
            ExperienceToDeleteVm eVm = new ExperienceToDeleteVm();

            if (eid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            eVm = _adapter.ExperienceToDelete(eid);

            if (eVm == null)
            {
                return HttpNotFound();
            }
            return View(eVm);
        }

        [HttpPost, ActionName("DeleteExperience")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int eid)
        {
            _adapter.DeleteExperience(eid);
            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }

    }
}