using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ForeCastController : Controller
    {
        // GET: ForeCast
        public ActionResult Index()
        {
            //City & country code are hardcoded, this can be moved to config file and put a logic here to select depending on what user has added in the url 
            ForecastBusinessLayer foreCst = new ForecastBusinessLayer("Sydney", "aus");
            ViewData["data"] = foreCst.GetWeatherForecast();
            return View();
        }
    }
}