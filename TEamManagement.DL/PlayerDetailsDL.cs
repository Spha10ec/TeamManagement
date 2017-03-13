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
    public class PlayerDetailsDL
    {
        private TeamManagementEntities db;

        public PlayerDetailsDL()
        {
            db = new TeamManagementEntities();
        }
        public IEnumerable<PlayerDetail> GetALL()
        {
            try
            {
                return db.PlayerDetails.ToList();
            }
             catch(Exception ex)
            {
                var list = new List<PlayerDetail>();
                list.Add
                    (
                            new PlayerDetail
                            {
                                FirstName = "Sipha",
                                id = 1,
                                DateOfBirth = DateTime.Now,
                                Height = 41,
                                Weight = 25,
                                LastName = "Blowu",
                                Notes = ex.InnerException.ToString(),

                            });
                return list;
            }
        }
        public PlayerDetail GetByID(int Id)
        {
            return db.PlayerDetails.Find(Id);
        }
        public string Insert(PlayerDetail user)
        {
            var errorMessage = String.Empty;
            try
            {
                db.PlayerDetails.Add(user);
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
            PlayerDetail user = db.PlayerDetails.Find(Id);
            db.PlayerDetails.Remove(user);
            Save();
        }
        public void Update(tbl_PlayerDetails user)
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
