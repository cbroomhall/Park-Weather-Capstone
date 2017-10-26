


using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Capstone.Web.Dal
{
    public class ParkWeatherSqlDal : IParkWeatherDal
    {
        private readonly string connectionString;
        private const string Sql_GetAllParks = "SELECT * FROM park";
        private const string Sql_GetSinglePark = "SELECT * FROM park WHERE parkCode = @id";
        private const string Sql_GetForecast = "SELECT * FROM weather JOIN park ON park.parkCode = weather.parkCode WHERE weather.parkCode = @id";
        private const string Sql_AddSurveyResult = "INSERT into survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
        private const string Sql_GetSurveyResults = @"SELECT count(survey_result.parkCode)as parkVote, park.parkName, park.parkCode FROM survey_result
                                                     JOIN park ON park.parkCode = survey_result.parkCode GROUP BY park.parkName, park.parkCode ORDER BY parkVote DESC";
       



        public ParkWeatherSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkModel> GetAllParks()
        {
            List<ParkModel> parkList = new List<ParkModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_GetAllParks, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel p = new ParkModel();
                        p.ParkCode = reader["parkCode"].ToString();
                        p.ParkName = reader["parkName"].ToString();
                        p.State = reader["state"].ToString();
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        p.NumberOfCapmpSites = Convert.ToInt32(reader["numberOfCampSites"]);
                        p.Climate = reader["climate"].ToString();
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVistorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = reader["inspirationalQuote"].ToString();
                        p.InspirationalQuoteSource = reader["inspirationalQuoteSource"].ToString();
                        p.ParkDescription = reader["parkDescription"].ToString();
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        parkList.Add(p);
                    }
                }
            }
            catch (SqlException e)
            {
                throw new NotImplementedException();
            }
            return parkList;
        }

        public ParkModel GetSinglePark(string id)
        {
            ParkModel p = new ParkModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_GetSinglePark, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        p.ParkCode = reader["parkCode"].ToString();
                        p.ParkName = reader["parkName"].ToString();
                        p.State = reader["state"].ToString();
                        p.Acreage = Convert.ToInt32(reader["acreage"]);
                        p.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        p.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        p.NumberOfCapmpSites = Convert.ToInt32(reader["numberOfCampSites"]);
                        p.Climate = reader["climate"].ToString();
                        p.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        p.AnnualVistorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        p.InspirationalQuote = reader["inspirationalQuote"].ToString();
                        p.InspirationalQuoteSource = reader["inspirationalQuoteSource"].ToString();
                        p.ParkDescription = reader["parkDescription"].ToString();
                        p.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        p.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        
                    }
                }
            }
            catch (SqlException e)
            {
                throw new NotImplementedException();
            }
            return p;
        }

        public List<WeatherModel> GetForecast(string id)
        {
            List<WeatherModel> weatherList = new List<WeatherModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_GetForecast, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        WeatherModel w = new WeatherModel();
                        w.ParkCode = reader["parkCode"].ToString();
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = reader["forecast"].ToString();

                        weatherList.Add(w);
                    }
                }
            }
            catch(SqlException e)
            {
                //throw new NotImplementedException();
            }
            return weatherList;
        }

        public bool AddSurveyResult(SurveyModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_AddSurveyResult, conn);
                    cmd.Parameters.AddWithValue("@parkcode", model.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", model.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", model.State);
                    cmd.Parameters.AddWithValue("@activityLevel", model.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }

            catch (SqlException e)
            {
                throw new NotImplementedException();
            }

        }

        public List<SurveyModel> GetSurveyResults()
        {
            List<SurveyModel> surveyList = new List<SurveyModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(Sql_GetSurveyResults, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyModel s = new SurveyModel();
                        s.ParkVote = Convert.ToInt32(reader["parkVote"]);
                        s.ParkName = reader["parkName"].ToString();
                        s.ParkCode = reader["parkCode"].ToString();

                        surveyList.Add(s);

                    }
                }

            }
            catch (SqlException e)
            {
                throw new NotImplementedException();

            }
            return surveyList;
        }
        public int TestMethod()
        {
            return 0;
        }

    }



   
}


