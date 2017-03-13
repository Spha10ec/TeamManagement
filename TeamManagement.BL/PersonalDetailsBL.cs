using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.BO;
using TEamManagement.DL;

namespace TeamManagement.BL
{
    public class PersonalDetailsBL
    {
        private PersonalDetailsDL personalDetails;

        public PersonalDetailsBL()
        {
            personalDetails = new PersonalDetailsDL();
        }

        public IEnumerable<PersonalDetail> GetALL()
        {
            return personalDetails.GetALL();
        }
        public PersonalDetail GetByID(int Id)
        {
            return personalDetails.GetByID(Id);
        }
        public string Insert(PersonalDetail url)
        {
            return personalDetails.Insert(url);
        }
        public void Delete(int Id)
        {
            personalDetails.Delete(Id);
        }
        public void Update(tbl_PersonalDetails url)
        {
            personalDetails.Update(url);
        }
    }
}
