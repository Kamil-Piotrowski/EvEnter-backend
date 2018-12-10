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
            var result = Database.Instance.znajomoscs;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_znajomosc(x)));
        }

        // GET: api/User/5
        public object Get(string login_zapraszajacego, string login_zaproszonego)
        {
            var result = Database.Instance.znajomoscs.Where(x => x.login_zapraszajacego == login_zapraszajacego && x.login_zaproszonego == login_zaproszonego);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_znajomosc(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]znajomosc value)
        {
            try
            {
                Database.Instance.znajomoscs.InsertOnSubmit((value));
                Database.Instance.SubmitChanges();
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
            var result = Database.Instance.znajomoscs.Where(x => x.login_zapraszajacego == login_zapraszajacego && x.login_zaproszonego == login_zaproszonego).FirstOrDefault();
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
        public IHttpActionResult Delete(string login_zapraszajacego, string login_zaproszonego)
        {
            var result = Database.Instance.znajomoscs.Where(x => x.login_zapraszajacego == login_zapraszajacego && x.login_zaproszonego == login_zaproszonego).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.znajomoscs.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
