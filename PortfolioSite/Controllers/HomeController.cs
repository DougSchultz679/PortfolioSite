﻿using System;
using System.Collections.Generic;
using System.Linq;
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