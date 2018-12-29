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
            DBDataContext db = new DBDataContext();
            var result = db.wiadomoscs;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc(x)));
        }

        // GET: api/User/5
        [Route("{id:int}")]
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.wiadomoscs.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc(x)));
        }
        [Route("my-conversations/{login}")]
        public IHttpActionResult Get(string login)
        {
            DBDataContext db = new DBDataContext();
            var messages = db.wiadomoscs.
                Where(x => x.login_odbiorcy == login || x.login_nadawcy == login);

            List<string> result = messages.Select(x => x.login_nadawcy).ToList();
            result.AddRange(messages.Select(x=>x.login_odbiorcy));
            result = result.Distinct().ToList();
            result.Remove(login);
            
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [Route("my-messages/{medashother}")]
        public object GetMyMessages(string medashother)
        {
            DBDataContext db = new DBDataContext();
            int dashIndex = medashother.IndexOf("-");
            string me = medashother.Substring(0, dashIndex);
            string other = medashother.Substring(dashIndex + 1, medashother.Length - 1 - me.Length);
            var result = db.wiadomoscs
                .Where(
                    x => 
                    x.login_odbiorcy == me && x.login_nadawcy == other
                    ||
                    x.login_nadawcy == me && x.login_odbiorcy == other
                    );
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_wiadomosc(x)));
        }

        // POST: api/User
        [Route("add")]
        public IHttpActionResult Post([FromBody]wiadomosc value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                int id;
                var ids = db.wiadomoscs.Select(x => x.id);
                if (ids.Count() > 0)
                    id = ids.Max() + 1;
                else
                    id = 1;
                wiadomosc w = new wiadomosc { id =(int) id, login_nadawcy = value.login_nadawcy, login_odbiorcy = value.login_odbiorcy, tresc = value.tresc, data_wyslania = value.data_wyslania };
                db.wiadomoscs.InsertOnSubmit((w));
                db.SubmitChanges();
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
            DBDataContext db = new DBDataContext();
            var result = db.wiadomoscs.Where(x => x.id == id).FirstOrDefault();
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
            var result = db.wiadomoscs.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                db.wiadomoscs.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
