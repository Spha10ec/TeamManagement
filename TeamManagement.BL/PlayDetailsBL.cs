﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagement.BO;
using TEamManagement.DL;

namespace TeamManagement.BL
{
    public class PlayDetailsBL
    {
        private PlayDetailsDL playDetails;

        public PlayDetailsBL()
        {
            playDetails = new PlayDetailsDL();
        }

        public IEnumerable<PlayDetail> GetALL()
        {
            return playDetails.GetALL();
        }

        public PlayDetail GetByID(int Id)
        {
            return playDetails.GetByID(Id);
        }
        public string Insert(PlayDetail playInfo)
        {
            return playDetails.Insert(playInfo);
        }
        public void Delete(int Id)
        {
            playDetails.Delete(Id);
        }
        public string Update(PlayDetail tblPlayDetails)
        {
            return playDetails.UpdateScores(tblPlayDetails);
        }
    }
}
