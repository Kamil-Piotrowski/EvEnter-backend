using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class Czlonkostwo_w_grupie_Controller : ApiController
    {
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.czlonkowstwo_w_grupies;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_czlonkowstwo_w_grupie(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.czlonkowstwo_w_grupies.Where(x => x.id_grupy == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_czlonkowstwo_w_grupie(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]czlonkowstwo_w_grupie value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.czlonkowstwo_w_grupies.InsertOnSubmit(value);
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        /*
        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]S_czlonkowstwo_w_grupie value)
        {
            var result = Database.Instance.czlonkowstwo_w_grupies.Where(x => x.id_grupy == id).FirstOrDefault();
            if (result != null)
            {
                //result.Name = value.Name;
                //result.HowManyLegs = value.HowManyLegs;
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return Ok("Nastąpił jakiś błąd");


        }
        */
        // DELETE: api/User/5
        public IHttpActionResult Delete(int id_grupy, string login_czlonka)
        {
            DBDataContext db = new DBDataContext();
            var result = db.czlonkowstwo_w_grupies.Where(x => x.id_grupy == id_grupy && x.login_czlonka == login_czlonka).FirstOrDefault();
            if (result != null)
            {
                db.czlonkowstwo_w_grupies.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
