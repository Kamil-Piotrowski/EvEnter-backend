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
            var result = Database.Instance.przeczytanie_wiadgrups;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_przeczytanie_wiadgrup(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            var result = Database.Instance.przeczytanie_wiadgrups.Where(x => x.id_wiadomosci_grup == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_przeczytanie_wiadgrup(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]przeczytanie_wiadgrup value)
        {
            try
            {
                Database.Instance.przeczytanie_wiadgrups.InsertOnSubmit((value));
                Database.Instance.SubmitChanges();
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
            var result = Database.Instance.przeczytanie_wiadgrups.Where(x => x.id_wiadomosci_grup == id).FirstOrDefault();
            if (result != null)
            {
                //result.Name = value.Name;
                //result.HowManyLegs = value.HowManyLegs;
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return Ok("Nastąpił jakiś błąd");


        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            var result = Database.Instance.przeczytanie_wiadgrups.Where(x => x.id_wiadomosci_grup == id).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.przeczytanie_wiadgrups.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
