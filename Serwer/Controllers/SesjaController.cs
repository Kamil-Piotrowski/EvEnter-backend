using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class SesjaController : ApiController
    {
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.Sesjas;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Sesja(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Sesjas.Where(x => x.id_sesji == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Sesja(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]Sesja value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.Sesjas.InsertOnSubmit((value));
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]Sesja value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Sesjas.Where(x => x.id_sesji == id).FirstOrDefault();
            if (result != null)
            {
                //result.Name = value.Name;
                //result.HowManyLegs = value.HowManyLegs;
                db.SubmitChanges();
                return Ok();
            }
            return Ok("Nastąpił jakiś błąd");


        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Sesjas.Where(x => x.id_sesji == id).FirstOrDefault();
            if (result != null)
            {
                db.Sesjas.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
