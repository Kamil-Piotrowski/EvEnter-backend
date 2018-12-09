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
            var result = Database.Instance.Sesjas;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Sesja(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            var result = Database.Instance.Sesjas.Where(x => x.id_sesji == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Sesja(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]S_Sesja value)
        {
            try
            {
                Database.Instance.Sesjas.InsertOnSubmit(S_Sesja.To_Sesja(value));
                Database.Instance.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]S_Sesja value)
        {
            var result = Database.Instance.Sesjas.Where(x => x.id_sesji == id).FirstOrDefault();
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
            var result = Database.Instance.Sesjas.Where(x => x.id_sesji == id).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.Sesjas.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
