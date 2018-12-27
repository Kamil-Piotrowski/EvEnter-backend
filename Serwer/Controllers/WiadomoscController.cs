using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    [RoutePrefix("api/Wiadomosc")]
    public class WiadomoscController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = Database.Instance.wiadomoscs;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc(x)));
        }

        // GET: api/User/5
        [Route("{id:int}")]
        public object Get(int id)
        {
            var result = Database.Instance.wiadomoscs.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc(x)));
        }

        // POST: api/User
        [Route("add")]
        public IHttpActionResult Post([FromBody]wiadomosc value)
        {
            try
            {
                int id;
                var ids = Database.Instance.wiadomoscs.Select(x => x.id);
                if (ids.Count() > 0)
                    id = ids.Max() + 1;
                else
                    id = 1;
                wiadomosc w = new wiadomosc { id =(int) id, login_nadawcy = value.login_nadawcy, login_odbiorcy = value.login_odbiorcy, tresc = value.tresc, data_wyslania = value.data_wyslania };
                Database.Instance.wiadomoscs.InsertOnSubmit((w));
                Database.Instance.SubmitChanges();
                return Ok();
            }
            catch(Exception e)
            {
                e.ToString();
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
