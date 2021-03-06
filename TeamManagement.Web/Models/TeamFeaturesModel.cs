﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Web.Models
{
    public class TeamFeaturesModel
    {
        public string errorMessage { get; set; }

        public bool isSuccessMessage { get; set; }

        public string successMessage { get; set; }

        public int TeamId { get; set; }
   //     public int id { get; set; }

        public int id { get; set; }

        public int recordId { get; set; }

        [DisplayName("My Team")]
        [Required]
        public string HomeTeam { get; set; }

        [DisplayName("Playing Against")]
        [Required]
        public string PlayingAgainst { get; set; }

        [DisplayName("Venue")]
        public string Venue { get; set; }

        [DisplayName("Season")]
        public string Season { get; set; }

        [DisplayName("Match Date")]
        public DateTime Date { get; set; }
        
        public string HomeScore { get; set; }
        public string AwayTeamScore { get; set; }
    }
}