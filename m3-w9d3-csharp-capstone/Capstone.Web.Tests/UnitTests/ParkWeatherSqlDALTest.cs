using Capstone.Web.Dal;
using Capstone.Web;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Tests.UnitTests
{   [TestClass]
    public class ParkWeatherSqlDALTest
    {
        string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";
        [TestMethod]
        public void GetAllParksTest()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                ParkWeatherSqlDal ParkWeatherDAL = new ParkWeatherSqlDal(connectionString);

                List<ParkModel> Parks = ParkWeatherDAL.GetAllParks();

                Assert.AreEqual(11, Parks.Count);
            }
        }

        [TestMethod]
        public void GetSingleParkTest()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                ParkWeatherSqlDal ParkWeatherDAL = new ParkWeatherSqlDal(connectionString);

                ParkModel Park = ParkWeatherDAL.GetSinglePark("CVNP");

                Assert.AreEqual("Cuyahoga Valley National Park", Park.ParkName);
            }
        }

        [TestMethod]
        public void GetForecastTest()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                ParkWeatherSqlDal ParkWeatherDAL = new ParkWeatherSqlDal(connectionString);

                List<WeatherModel> Weather  = ParkWeatherDAL.GetForecast("CVNP");

                Assert.AreEqual(38, Weather[0].Low);
            }
        }

        //[TestMethod]
        //public void GetSurveyResults()
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        ParkWeatherSqlDal ParkWeatherDAL = new ParkWeatherSqlDal(connectionString);

        //        List<SurveyModel> Surveys = ParkWeatherDAL.GetSurveyResults();

        //        Assert.AreEqual(38, Weather[0].Low);
        //    }

        //}
    }

}
