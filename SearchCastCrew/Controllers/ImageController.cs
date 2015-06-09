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
    public class ImageController : Controller
    {
        IUserAdapter _adapter;

        public ImageController()
        {
            _adapter = new UserDataAdapter();
        }

        public ImageController(IUserAdapter adp)
        {
            _adapter = adp;
        }

        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        // Add an Image
        public ActionResult AddImage()
        {
            ImageAddVm iVm = new ImageAddVm();

            return View(iVm);
        }

        [HttpPost]
        public ActionResult AddImage(ImageAddVm nVm)
        {
            nVm.NewImage.UserId = User.Identity.GetUserId();
            _adapter.AddImage(nVm);

            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }

        // Delete an Image
        public ActionResult DeleteImage(int imgId)
        {
            ImageToDeleteVm dVm = new ImageToDeleteVm();

            if (imgId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            dVm = _adapter.ImageToDelete(imgId);

            if (dVm == null)
            {
                return HttpNotFound();
            }
            return View(dVm);
        }

        [HttpPost]
        public ActionResult DeleteImage(ImageToDeleteVm ivm)
        {
            _adapter.DeleteImage(ivm);
            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }
        //setting it as profile picture
        public ActionResult SetProfilePicture(int imgId)
        {
            ImageProfileVm ipVm = new ImageProfileVm();

            ipVm = _adapter.ImageToEdit(imgId);

            return View(ipVm);
        }

        [HttpPost]
        public ActionResult SetProfilePicture(ImageProfileVm ipVm)
        {
            ipVm.UserId = User.Identity.GetUserId();
            _adapter.SetProfilePicture(ipVm);

            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }


    }
}