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
                return db.PlayDetails.ToList().OrderBy(x =>x.FixtureDate);
           
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
        public string Update(PlayDetail playDetails)
        {
             var errorMessage = String.Empty;
             try
             {
                
                 db.Entry(playDetails).State = EntityState.Modified;
                 db.Configuration.ValidateOnSaveEnabled = false;
                 Save();
                 db.Configuration.ValidateOnSaveEnabled = true;
                 return errorMessage;
             }
             catch (Exception ex)
             {
                 errorMessage = ex.Message;
                 return errorMessage;
             }
        }

        public string UpdateScores(PlayDetail playDetails)
        {
            var errorMessage = String.Empty;
            try
            {
                db.PlayDetails.Attach(playDetails);
                db.Entry(playDetails).Property(x => x.AwayScore).IsModified = true;
                db.Entry(playDetails).Property(x => x.HomeScore).IsModified = true;
                db.Configuration.ValidateOnSaveEnabled = false;
                Save();
                db.Configuration.ValidateOnSaveEnabled = true;
                return errorMessage;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return errorMessage;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
