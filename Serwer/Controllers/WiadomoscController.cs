using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class WiadomoscController : ApiController
    {
        public IHttpActionResult Get()
        {
            var result = Database.Instance.wiadomoscs;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            var result = Database.Instance.wiadomoscs.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]wiadomosc value)
        {
            try
            {
                Database.Instance.wiadomoscs.InsertOnSubmit((value));
                Database.Instance.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]wiadomosc value)
        {
            var result = Database.Instance.wiadomoscs.Where(x => x.id == id).FirstOrDefault();
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
            var result = Database.Instance.wiadomoscs.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.wiadomoscs.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
