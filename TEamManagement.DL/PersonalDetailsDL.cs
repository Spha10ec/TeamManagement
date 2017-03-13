using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.BO;

namespace TEamManagement.DL
{
    public class PersonalDetailsDL
    {
        private TeamManagementEntities db;

        public PersonalDetailsDL()
        {
            db = new TeamManagementEntities();
        }
        public IList<PersonalDetail> GetALL()
        {
            var list = new List<PersonalDetail>();
            list.Add
                (
                        new PersonalDetail
                        {
                            FirstName = "Sipha",
                            id = 1,
                            IdNumber = "20145886",
                            Surname = "Blowu"

                        });
            return list;
        }
        public PersonalDetail GetByID(int Id)
        {
            return db.PersonalDetails.Find(Id);
        }
        public string Insert(PersonalDetail user)
        {
            var errorMessage = String.Empty;
            try
            {
                db.PersonalDetails.Add(user);
                db.SaveChanges();
                return errorMessage;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return errorMessage;
            }

            
        }
        public void Delete(int Id)
        {
            PersonalDetail user = db.PersonalDetails.Find(Id);
            db.PersonalDetails.Remove(user);
            Save();
        }
        public void Update(tbl_PersonalDetails user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
