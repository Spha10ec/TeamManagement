using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamManagement.BL;
using TeamManagement.Web.Models;

namespace TeamManagement.Web.Controllers
{
    public class PersonAPIController : ApiController
    {
      //  private SurveyDBEntities db = new SurveyDBEntities();

        // GET: api/PersonAPI
        public IQueryable<PlayerDetailsList> GetPersonInformations()
        {
            var listOfPlayers = new PlayerDetailsBL();
            var playerDetailsList = new List<PlayerDetailsList>();

            var playerDetails = listOfPlayers.GetALL();

            foreach (var player in playerDetails)
            {
                playerDetailsList.Add
                (
                     new PlayerDetailsList
                     {
                         DateOfBirth = player.DateOfBirth,
                         FirstName = player.FirstName,
                         LastName = player.LastName,
                         Weight = player.Weight,
                         Height = player.Height,
                         Notes = player.Notes

                     });
            }
            return playerDetailsList.AsQueryable();
        }

        // GET: api/PersonAPI/5
        //[ResponseType(typeof(PersonInformation))]
        //public IHttpActionResult GetPersonInformation(int id)
        //{
        //    PersonInformation personInformation = db.PersonInformations.Find(id);
        //    if (personInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(personInformation);
        //}

        //// PUT: api/PersonAPI/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPersonInformation(int id, PersonInformation personInformation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != personInformation.PersonId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(personInformation).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PersonInformationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/PersonAPI
        //[ResponseType(typeof(PersonInformation))]
        //public IHttpActionResult PostPersonInformation(PersonInformation personInformation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PersonInformations.Add(personInformation);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = personInformation.PersonId }, personInformation);
        //}

        //// DELETE: api/PersonAPI/5
        //[ResponseType(typeof(PersonInformation))]
        //public IHttpActionResult DeletePersonInformation(int id)
        //{
        //    PersonInformation personInformation = db.PersonInformations.Find(id);
        //    if (personInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PersonInformations.Remove(personInformation);
        //    db.SaveChanges();

        //    return Ok(personInformation);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PersonInformationExists(int id)
        //{
        //    return db.PersonInformations.Count(e => e.PersonId == id) > 0;
        //}
    }
}
