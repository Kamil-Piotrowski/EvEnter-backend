using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class Ocena_WydarzeniaController : ApiController
    {
        public IHttpActionResult Get()
        {
            var result = Database.Instance.ocena_wydarzenias;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_ocena_wydarzenia(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            var result = Database.Instance.ocena_wydarzenias.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_ocena_wydarzenia(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]S_ocena_wydarzenia value)
        {
            try
            {
                Database.Instance.ocena_wydarzenias.InsertOnSubmit(S_ocena_wydarzenia.To_ocena_wspoluczestnika(value));
                Database.Instance.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]S_ocena_wydarzenia value)
        {
            var result = Database.Instance.ocena_wydarzenias.Where(x => x.id == id).FirstOrDefault();
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
            var result = Database.Instance.ocena_wydarzenias.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.ocena_wydarzenias.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
