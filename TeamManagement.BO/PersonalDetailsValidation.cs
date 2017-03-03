using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagement.BO
{
    public class UniqueIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            TeamManagementEntities db = new TeamManagementEntities();
            string idNumber = value.ToString();
            int count = db.PersonalDetails.Where(x => x.IdNumber == idNumber).ToList().Count();
            if (count != 0)
                return new ValidationResult("User Already Exist With This  ID number");
            return ValidationResult.Success;
        }
    }
    public class PersonalDetailsValidation
    {
        [Required]
        public string FirstName { get; set; }

       [Required]
       [UniqueId]
        public string IdNumber { get; set; }

        [Required]
        public string Surname { get; set; }

    }
    [MetadataType(typeof(PersonalDetailsValidation))]
    public partial class tbl_PersonalDetails
    {

    }
}
