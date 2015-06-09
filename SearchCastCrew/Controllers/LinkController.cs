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
    public class LinkController : Controller
    {
        IUserAdapter _adapter;

        public LinkController()
        {
            _adapter = new UserDataAdapter();
        }

        public LinkController(IUserAdapter adp)
        {
            _adapter = adp;
        }

        // GET: Link
        public ActionResult Index()
        {
            return View();
        }

        // Add an Link entry
        public ActionResult AddLink()
        {
            LinkAddVm lVm = new LinkAddVm();

            return View(lVm);
        }

        [HttpPost]
        public ActionResult AddLink(LinkAddVm lVm)
        {
            lVm.NewLink.UserId = User.Identity.GetUserId();
            _adapter.AddLink(lVm);

            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }

        // Delete a Link entry
        public ActionResult DeleteLink(int lid)
        {
            LinkToDeleteVm lVm = new LinkToDeleteVm();

            if (lid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            lVm = _adapter.LinkToDelete(lid);

            if (lVm == null)
            {
                return HttpNotFound();
            }
            return View(lVm);
        }

        [HttpPost, ActionName("DeleteLink")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int lid)
        {
            _adapter.DeleteLink(lid);
            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() } );
        }
    }
}