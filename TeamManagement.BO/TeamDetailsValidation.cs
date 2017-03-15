using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagement.BO
{

    public class TeamDetailsValidation
    {
        [Required]
        [UniqueId]
        public int Id { get; set; }

       [Required]
        public string TeamName { get; set; }
       
        public string SeasonYear { get; set; }

        public string SportCode { get; set; }

        public string Motto { get; set; }

    }
    [MetadataType(typeof(TeamDetailsValidation))]
    public partial class tbl_TeamDetails
    {

    }
}
