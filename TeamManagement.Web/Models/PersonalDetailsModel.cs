using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TeamManagement.Web.Models
{
    public class PersonalDetailsModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("ID Number")]
        public string IdNumber { get; set; }
    }
}