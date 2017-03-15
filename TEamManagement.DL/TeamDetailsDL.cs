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
    public class TeamDetailsDL
    {
        private TeamManagementEntities db;

        public TeamDetailsDL()
        {
            db = new TeamManagementEntities();
        }
        public IEnumerable<Team> GetALL()
        {
            return db.Teams.ToList();
           
        }
        public Team GetSingle()
        {
            return db.Teams.FirstOrDefault();

        }
        public Team GetByID(int Id)
        {
            return db.Teams.Find(Id);
        }
        public string Insert(Team teamDetail)
        {
            var errorMessage = String.Empty;
            try
            {
                db.Teams.Add(teamDetail);
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
            Team teamDetail = db.Teams.Find(Id);
            db.Teams.Remove(teamDetail);
            Save();
        }
        public void Update(tbl_TeamDetails teamDetails)
        {
            db.Entry(teamDetails).State = EntityState.Modified;
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
