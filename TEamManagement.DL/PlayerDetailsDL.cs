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
            return db.PlayerDetails.ToList();
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
