using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class Przeczytanie_wiadgrupController : ApiController
    {
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.przeczytanie_wiadgrups;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_przeczytanie_wiadgrup(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.przeczytanie_wiadgrups.Where(x => x.id_wiadomosci_grup == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_przeczytanie_wiadgrup(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]przeczytanie_wiadgrup value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.przeczytanie_wiadgrups.InsertOnSubmit((value));
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]przeczytanie_wiadgrup value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.przeczytanie_wiadgrups.Where(x => x.id_wiadomosci_grup == id).FirstOrDefault();
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
            var result = db.przeczytanie_wiadgrups.Where(x => x.id_wiadomosci_grup == id).FirstOrDefault();
            if (result != null)
            {
                db.przeczytanie_wiadgrups.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
