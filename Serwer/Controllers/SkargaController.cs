using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class SkargaController : ApiController
    {
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.skargas;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_skarga(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.skargas.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_skarga(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]skarga value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.skargas.InsertOnSubmit((value));
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]skarga value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.skargas.Where(x => x.id == id).FirstOrDefault();
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
            var result = db.skargas.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                db.skargas.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
