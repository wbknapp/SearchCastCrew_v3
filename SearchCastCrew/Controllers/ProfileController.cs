using SearchCastCrew.Adapters;
using SearchCastCrew.Data;
using SearchCastCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SearchCastCrew.Controllers
{
    public class ProfileController : Controller
    {
        private IUserAdapter _adapter;

        public ProfileController()
        {
            _adapter = new UserDataAdapter();
        }
        public ProfileController(IUserAdapter adapter)
        {
            _adapter = adapter;
        }

        public ActionResult Index(string uid)
        {
            //string uid = User.Identity.GetUserId();
            //UserProfileVm pvm = new UserProfileVm();
            //    pvm = _adapter.GetUser(string uid);
            //    return View(pvm);
            var z = uid;
            UserProfileVm pVm = new UserProfileVm();
            pVm = _adapter.GetUser(uid);

            return View(pVm);
        }
    }
}