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
    public class VideoController : Controller
    {
        IUserAdapter _adapter;

        public VideoController()
        {
            _adapter = new UserDataAdapter();
        }

        public VideoController(IUserAdapter adp)
        {
            _adapter = adp;
        }

        // GET: Video
        public ActionResult Index()
        {

            return View();
        }

        // Add a video
        public ActionResult AddVideo()
        {
            VideoAddVm avm = new VideoAddVm();

            return View(avm);
        }

        [HttpPost]
        public ActionResult AddVideo(VideoAddVm nVm)
        {
            nVm.NewVideo.UserId = User.Identity.GetUserId();
            _adapter.AddVideo(nVm);

            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }

        // Delete a Video
        public ActionResult DeleteVideo(int vid)
        {
            VideoToDeleteVm dVm = new VideoToDeleteVm();

            if (vid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            dVm = _adapter.VideoToDelete(vid);

            if (dVm == null)
            {
                return HttpNotFound();
            }
            return View(dVm);
        }

        [HttpPost, ActionName("DeleteVideo")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int vid)
        {
            _adapter.DeleteVideo(vid);
            return RedirectToAction("ViewProfile", "Home", new { uid = User.Identity.GetUserId() });
        }
    }
}