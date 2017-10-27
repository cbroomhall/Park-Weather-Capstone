using Capstone.Web.Dal;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ParkWeatherDb"].ConnectionString;
        private readonly IParkWeatherDal applicationDal;

        public HomeController(IParkWeatherDal applicationDal)
        {
            this.applicationDal = applicationDal;
        }

        // GET: Home
        public ActionResult Index()
        {
            ParkWeatherSqlDal p = new ParkWeatherSqlDal(connectionString);
            List<ParkModel> parkList = new List<ParkModel>();
            parkList = p.GetAllParks();
            //int x = applicationDal.TestMethod();
            return View("Index", parkList);
        }

        public ActionResult Details(string id)
        {
            ParkWeatherSqlDal p = new ParkWeatherSqlDal(connectionString);
            ParkModel park = new ParkModel();
            park = p.GetSinglePark(id);
            return View(park);
        }

        public ActionResult Forecast(string id)
        {
            ParkWeatherSqlDal w = new ParkWeatherSqlDal(connectionString);
            List<WeatherModel> weather = new List<WeatherModel>();
            weather = w.GetForecast(id);
            bool? tempList = Session["Preference"] as bool?;

            if (tempList == null)
            {
                Session["Preference"] = true;
            }
            else
            {
                foreach (WeatherModel wM in weather)
                {
                    wM.IsFahrenheit = Session["Preference"] as bool?;
                }
            }
            return View(weather);
        }

        public ActionResult NewSurvey()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSurvey(SurveyModel model)
        {
            ParkWeatherSqlDal w = new ParkWeatherSqlDal(connectionString);
            w.AddSurveyResult(model);

            if (!ModelState.IsValid)
            {
                return View("NewSurvey", model);
            }

            return RedirectToAction("Surveys", "Home");
        }

        public ActionResult Surveys()
        {
            ParkWeatherSqlDal w = new ParkWeatherSqlDal(connectionString);
            List<SurveyModel> surveys = new List<SurveyModel>();
            surveys = w.GetSurveyResults();

            return View(surveys);
        }

        public ActionResult Preferences()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Preferences (WeatherModel model)
        {
            Session["Preference"] = model.IsFahrenheit;

            return RedirectToAction("PreferencesResult");
        }

        public ActionResult PreferencesResult()
        {
            return View();
        }
    }
}