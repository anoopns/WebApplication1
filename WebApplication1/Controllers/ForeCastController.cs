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
            ForecastBusinessLayer foreCst = new ForecastBusinessLayer();
            List<Forecast> forecastData = foreCst.GetWeatherForecast();
            ViewData["count"] = forecastData.Count;
            ViewData["data"] = forecastData;
            ViewData["noOfsunnyDays"] = forecastData.FindAll(x => x.Weather.ToLower().Contains("sunny")).Count;
            return View();
        }
    }
}