using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.BO;
using TEamManagement.DL;

namespace TeamManagement.BL
{
    public class TeamDetailsBL
    {
        private TeamDetailsDL teamDetails;

        public TeamDetailsBL()
        {
            teamDetails = new TeamDetailsDL();
        }

        public IEnumerable<Team> GetALL()
        {
            return teamDetails.GetALL();
        }

        public Team GetByID(int Id)
        {
            return teamDetails.GetByID(Id);
        }
        public string Insert(Team playInfo)
        {
            return teamDetails.Insert(playInfo);
        }
        public void Delete(int Id)
        {
            teamDetails.Delete(Id);
        }
        public void Update(tbl_TeamDetails tblPlayDetails)
        {
            teamDetails.Update(tblPlayDetails);
        }
    }
}
