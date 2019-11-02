using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using H2OCRUDLibrary2;
using System.Web.Http.Cors;

namespace MuncipalH2OWebAPI2.Controllers
{
   [EnableCors("*", "*", "*")]
   [RoutePrefix("api/MuncipalCANs")]
   public class MuncipalCANsController : ApiController
    {
        private masterEntities2 db = new masterEntities2();

        // GET: api/MuncipalCANs
        [Route("")]
        public IQueryable<MuncipalCAN> GetMuncipalCANs()
        {
            return db.MuncipalCANs;
        }

        // GET: api/MuncipalCANs/5
        [ResponseType(typeof(MuncipalCAN))]
      [Route("{id:int}")]
      public IHttpActionResult GetMuncipalCAN(decimal id)
        {
            MuncipalCAN muncipalCAN = db.MuncipalCANs.Find(id);
            if (muncipalCAN == null)
            {
                return NotFound();
            }

            return Ok(muncipalCAN);
      }

      // GET: api/MuncipalCANs2/5
      [ResponseType(typeof(IQueryable<MuncipalCAN>))]
      [Route("RWHS/{value:bool}")]
      public IHttpActionResult GetMuncipalCANsByRWHS(bool value)
      {
         IQueryable<MuncipalCAN> foundRecords = from can in db.MuncipalCANs
                                                where can.RWHS == value
                                                select can;

         return Ok(foundRecords);
      }

      [ResponseType(typeof(IQueryable<MuncipalCAN>))]
      [Route("RecyclingPlant/{value:bool}")]
      // [Route("MuncipalCANs/RWHS")]
      public IHttpActionResult GetMuncipalCANsByRecyclingPlant(bool value)
      {
         IQueryable<MuncipalCAN> foundRecords = from can in db.MuncipalCANs
                                                where can.RecyclingPlant == value
                                                select can;

         return Ok(foundRecords);
      }

      [ResponseType(typeof(IQueryable<MuncipalCAN>))]
      [Route("UsageScore/{start:int}/{end:int}")]
      public IHttpActionResult GetMuncipalCANsByUsageScore(int start, int end)
      {
         IQueryable<MuncipalCAN> foundRecords =
            db.MuncipalCANs.Where(can => can.UsageScore >= start & can.UsageScore < end);

         return Ok(foundRecords);
      }

      // PUT: api/MuncipalCANs/5
      [ResponseType(typeof(void))]
      [Route("{id:int}")]
      public IHttpActionResult PutMuncipalCAN(decimal id, MuncipalCAN muncipalCAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muncipalCAN.PhoneNumber)
            {
                return BadRequest();
            }

            db.Entry(muncipalCAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuncipalCANExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MuncipalCANs
        [ResponseType(typeof(MuncipalCAN))]
      [Route("")]
      public IHttpActionResult PostMuncipalCAN(MuncipalCAN muncipalCAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MuncipalCANs.Add(muncipalCAN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MuncipalCANExists(muncipalCAN.PhoneNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = muncipalCAN.PhoneNumber }, muncipalCAN);
        }

        // DELETE: api/MuncipalCANs/5
        [ResponseType(typeof(MuncipalCAN))]
      [Route("{id:int}")]
      public IHttpActionResult DeleteMuncipalCAN(decimal id)
        {
            MuncipalCAN muncipalCAN = db.MuncipalCANs.Find(id);
            if (muncipalCAN == null)
            {
                return NotFound();
            }

            db.MuncipalCANs.Remove(muncipalCAN);
            db.SaveChanges();

            return Ok(muncipalCAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MuncipalCANExists(decimal id)
        {
            return db.MuncipalCANs.Count(e => e.PhoneNumber == id) > 0;
        }
    }
}