using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }
        [Required]
        public string ParkCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be valid e-mail address.")]
        public string EmailAddress { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ActivityLevel { get; set; }
        public int ParkVote { get; set; }
        
        public string ParkName { get; set; }

    }
}