using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
                //var manager = new UserManager<TrimUser>(new UserStore<TrimUser>(db));
                //var currentUser = manager.FindById(User.Identity.GetUserId());
                //ViewBag.user = currentUser;
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("nielson.joseph@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("admin@trim.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}