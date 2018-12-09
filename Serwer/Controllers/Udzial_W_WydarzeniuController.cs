using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class Udzial_W_WydarzeniuController : ApiController
    {
        public IHttpActionResult Get()
        {
            var result = Database.Instance.udzial_w_wydarzenius;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_udzial_w_wydarzeniu(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            var result = Database.Instance.udzial_w_wydarzenius.Where(x => x.id_wydarzenia == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_udzial_w_wydarzeniu(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]S_udzial_w_wydarzeniu value)
        {
            try
            {
                Database.Instance.udzial_w_wydarzenius.InsertOnSubmit(S_udzial_w_wydarzeniu.To_udzial_w_wydarzeniu(value));
                Database.Instance.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]S_udzial_w_wydarzeniu value)
        {
            var result = Database.Instance.udzial_w_wydarzenius.Where(x => x.id_wydarzenia == id).FirstOrDefault();
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
            var result = Database.Instance.udzial_w_wydarzenius.Where(x => x.id_wydarzenia == id).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.udzial_w_wydarzenius.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
