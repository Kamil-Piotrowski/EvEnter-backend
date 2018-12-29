using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class ZnajomoscController : ApiController
    {
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.znajomoscs;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_znajomosc(x)));
        }

        // GET: api/User/5
        public object Get(string login_zapraszajacego, string login_zaproszonego)
        {
            DBDataContext db = new DBDataContext();
            var result = db.znajomoscs.Where(x => x.login_zapraszajacego == login_zapraszajacego && x.login_zaproszonego == login_zaproszonego);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_znajomosc(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]znajomosc value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.znajomoscs.InsertOnSubmit((value));
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(string login_zapraszajacego, string login_zaproszonego, [FromBody]znajomosc value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.znajomoscs.Where(x => x.login_zapraszajacego == login_zapraszajacego && x.login_zaproszonego == login_zaproszonego).FirstOrDefault();
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
        public IHttpActionResult Delete(string login_zapraszajacego, string login_zaproszonego)
        {
            DBDataContext db = new DBDataContext();
            var result = db.znajomoscs.Where(x => x.login_zapraszajacego == login_zapraszajacego && x.login_zaproszonego == login_zaproszonego).FirstOrDefault();
            if (result != null)
            {
                db.znajomoscs.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
