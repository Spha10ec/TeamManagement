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
  public IEnumerable<PersonalDetail> GetALL()
       {
           return db.PersonalDetails.ToList();
       }
  public PersonalDetail GetByID(int Id)
       {
           return db.PersonalDetails.Find(Id);
       }
  public void Insert(PersonalDetail user)
       {
           db.PersonalDetails.Add(user);
           Save();
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
