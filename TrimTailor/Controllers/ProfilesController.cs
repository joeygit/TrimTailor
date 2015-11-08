using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrimTailor.Models;

namespace TrimTailor.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profiles
        public ActionResult Index()
        {
            var profile = db.Profile.Include(p => p.TrimUser);
            return View(profile.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(string id)
        {
            var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            if (currentUser.Id == id)
            {
                return View(profile);
            }
            else
            {
                return RedirectToAction("Details", new { id = currentUser.Id });
            } 
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (!(currentUser.Profile == null))
            {
               return RedirectToAction("Edit", new { id = currentUser.Profile.TrimUserId });
            }

            //ViewBag.Id = new SelectList(db.TrimUsers, "Id", "Email");
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrimUserId,created_at,updated_at,mes_waist,mes_stomach,mes_shoulders,mes_neck,mes_chest,mes_torso,mes_inseam,mes_rightarm,mes_leftarm,mes_necktoshoulder,mes_heightft,mes_heightin,mes_weight")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                //create new profile if user previously deleted theirs
                // do we need this?...
                if (currentUser.Profile == null)
                {
                    currentUser.Profile = profile;
                    currentUser.Profile.created_at = DateTime.Now;
                    currentUser.Profile.updated_at = DateTime.Now;
                    //db.Entry(profile).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = profile.TrimUserId });
                }
                else if (!(currentUser.Profile == null))
                {
                   return RedirectToAction("Edit", new { id = currentUser.Profile.TrimUserId });
                }
                
            }

            return View(profile);

            //ViewBag.TrimUserId = new SelectList(db.TrimUsers, "Id", "Email", profile.TrimUserId);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(string id)
        {
            var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            if (currentUser.Id == id)
            {
                return View(profile);
            }
            else
            {
                return RedirectToAction("Details", new { id = currentUser.Id });
            }
                
            //ViewBag.TrimUserId = new SelectList(db.TrimUsers, "Id", "Email", profile.TrimUserId);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrimUserId,created_at,updated_at,mes_waist,mes_stomach,mes_shoulders,mes_neck,mes_chest,mes_torso,mes_inseam,mes_rightarm,mes_leftarm,mes_necktoshoulder,mes_heightft,mes_heightin,mes_weight")] Profile profile)
        {
            var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid && currentUser.Id == profile.TrimUserId)
            {
                profile.updated_at = DateTime.Now;
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = profile.TrimUserId });
            }
            return View(profile);
            // ViewBag.TrimUserId = new SelectList(db.TrimUsers, "Id", "Email", profile.TrimUserId);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(string id)
        {
            var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if ((currentUser == null) || (currentUser.Id == id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if ((currentUser == null) || (currentUser.Id == id))
            {
                Profile profile = db.Profile.Find(id);
                db.Profile.Remove(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
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
