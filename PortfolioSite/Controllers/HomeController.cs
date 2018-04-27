using PortfolioSite.Helpers;
using PortfolioSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortfolioSite.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactSend([Bind(Include = "FromName,FromEmail,Subject,Body,Dummy")]ContactMsg contactMsg)
        {
            if (ModelState.IsValid && String.IsNullOrEmpty(contactMsg.Dummy))
            {
                ContactEmailSender ces = new ContactEmailSender();

                await ces.SendContactMsg(contactMsg);

                //FIX THIS
                return null;
            } else return null;
        }

        public ActionResult JSExercise()
        {
            return View();
        }
        public ActionResult JqueryExercise()
        {
            return View();
        }
    }
}
