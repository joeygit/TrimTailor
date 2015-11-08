using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrimTailor.Models;

namespace TrimTailor.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            { 
               var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
               var currentUser = manager.FindById(User.Identity.GetUserId());
               ViewBag.user = currentUser;
               return View(currentUser);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Trim will make you look dapper. Better buy a fish bat to keep the women off of you!";
            if (Request.IsAuthenticated)
            {
                var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                ViewBag.user = currentUser;
                return View(currentUser);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Let us know what you think!";
            if (Request.IsAuthenticated)
            {
                var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                ViewBag.user = currentUser;
                return View(currentUser);
            }
            return View();
        }
    }
}