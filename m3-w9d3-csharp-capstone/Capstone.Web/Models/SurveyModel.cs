using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }
        public int ParkVote { get; set; }
        public string ParkName { get; set; }

    }
}