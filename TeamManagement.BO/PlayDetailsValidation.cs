using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagement.BO
{

    public class PlayDetailsValidation
    {
        [Required]
        [UniqueId]
        public int Id { get; set; }

       [Required]
        public string TeamDetails { get; set; }
       
        public string FixtureDate { get; set; }

        public string HomeScore { get; set; }

        public string AwayScore { get; set; }

        public string TeamId { get; set; }

    }
    [MetadataType(typeof(PlayDetailsValidation))]
    public partial class tbl_PlayDetails
    {

    }
}
