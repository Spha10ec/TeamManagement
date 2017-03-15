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
    public class PlayDetailsDL
    {
        private TeamManagementEntities db;

        public PlayDetailsDL()
        {
            db = new TeamManagementEntities();
        }
        public IEnumerable<PlayDetail> GetALL()
        {
                return db.PlayDetails.ToList();
           
        }
        public PlayDetail GetByID(int Id)
        {
            return db.PlayDetails.Find(Id);
        }
        public string Insert(PlayDetail playDetail)
        {
            var errorMessage = String.Empty;
            try
            {
                db.PlayDetails.Add(playDetail);
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
            PlayDetail playDetail = db.PlayDetails.Find(Id);
            db.PlayDetails.Remove(playDetail);
            Save();
        }
        public void Update(tbl_PlayDetails playDetails)
        {
            db.Entry(playDetails).State = EntityState.Modified;
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
