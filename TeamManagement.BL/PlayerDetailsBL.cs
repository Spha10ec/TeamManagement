using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.BO;
using TEamManagement.DL;

namespace TeamManagement.BL
{
    public class PlayerDetailsBL
    {
        private PlayerDetailsDL playerDetails;

        public PlayerDetailsBL()
        {
            playerDetails = new PlayerDetailsDL();
        }

        public IEnumerable<PlayerDetail> GetALL()
        {
            return playerDetails.GetALL();
        }

        public PlayerDetail GetByID(int Id)
        {
            return playerDetails.GetByID(Id);
        }
        public string Insert(PlayerDetail url)
        {
            return playerDetails.Insert(url);
        }
        public void Delete(int Id)
        {
            playerDetails.Delete(Id);
        }
        public void Update(tbl_PlayerDetails url)
        {
            playerDetails.Update(url);
        }
    }
}
