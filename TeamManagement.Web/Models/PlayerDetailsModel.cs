using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Web.Models
{
    public class PlayerDetailsModel
    {
        public string errorMessage { get; set; }

        public bool successMessage { get; set; }

        public List<PlayerDetailsList> playerDetailsList { get; set; }
      
    }
    public class PlayerDetailsList
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Weight")]
        public decimal Weight { get; set; }

        [DisplayName("Height")]
        public decimal Height { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }
    }
}