using Capstone.Web.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Tests.UnitTests
{
    class ParkWeatherSqlDALTest
    {
        string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";
        [TestMethod]
        public void SurveyTest()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                CampGroundDAL campGroundDAL = new CampGroundDAL(connectionString);

                List<CampGround> camps = campGroundDAL.GetCampground();

                Assert.AreEqual(7, camps.Count);
            }
        }
    }

}
