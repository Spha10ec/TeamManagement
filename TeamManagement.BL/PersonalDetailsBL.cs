using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.BO;

namespace TeamManagement.BL
{
    public class PersonalDetailsBL
    {
            private PersonalDetails personalDetails;

            public PersonalDetailsBL()
        {
            personalDetails = new PersonalDetails();
        }

            public IEnumerable<PersonalDetails> GetALL()
        {
            return personalDetails.GetALL();
        }

        public tbl_Url GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_Url url)
        {
            objDb.Insert(url);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_Url url)
        {
            objDb.Update(url);
        }
    }
}
