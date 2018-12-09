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
            var result = Database.Instance.skargas;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_skarga(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            var result = Database.Instance.skargas.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_skarga(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]S_skarga value)
        {
            try
            {
                Database.Instance.skargas.InsertOnSubmit(S_skarga.To_skarga(value));
                Database.Instance.SubmitChanges();
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
            var result = Database.Instance.skargas.Where(x => x.id == id).FirstOrDefault();
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
            var result = Database.Instance.skargas.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.skargas.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
