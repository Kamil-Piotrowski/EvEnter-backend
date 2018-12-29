using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class Wiadomosc_GrupowaController : ApiController
    {
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.wiadomosc_grupowas;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc_grupowa(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.wiadomosc_grupowas.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc_grupowa(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]wiadomosc_grupowa value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.wiadomosc_grupowas.InsertOnSubmit((value));
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]wiadomosc_grupowa value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.wiadomosc_grupowas.Where(x => x.id == id).FirstOrDefault();
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
            var result = db.wiadomosc_grupowas.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                db.wiadomosc_grupowas.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
