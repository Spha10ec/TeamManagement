using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Web.Models
{
    public class TeamModel
    {
        public string errorMessage { get; set; }

        public bool successMessage { get; set; }

        public int Id { get; set; }

        [DisplayName("Team Name")]
        [Required]
        public string TeamName { get; set; }

        [DisplayName("Season Year")]
        [Required]
        public string SeasonYear { get; set; }

        [DisplayName("SportCode")]
        public string SportCode { get; set; }

        [DisplayName("Motto")]
        public string Motto { get; set; }

    }

}