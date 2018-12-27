using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    [RoutePrefix("api/Uzytkownik")]
    public class UzytkownikController : ApiController
    {
        // GET: api/Uzytkownik
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = Database.Instance.Uzytkowniks;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Uzytkownik(x)));
        }

        // GET: api/Uzytkownik/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var result = Database.Instance.Uzytkowniks.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Uzytkownik(x)));
        }
        [Route("login/{login}")]
        public IHttpActionResult Get(string login)
        {
            var result = Database.Instance.Uzytkowniks.Where(x => x.login == login);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Uzytkownik(x)));
        }

        // POST: api/Uzytkownik
        public IHttpActionResult Post([FromBody]Uzytkownik value)
        {
            try
            {
                Database.Instance.Uzytkowniks.InsertOnSubmit(value);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/Uzytkownik/5
        public IHttpActionResult Put(string login, [FromBody]Uzytkownik value)
        {
            var result = Database.Instance.Uzytkowniks.Where(x => x.login == login).FirstOrDefault();
            if (result != null)
            {
                //result.Name = value.Name;
                //result.HowManyLegs = value.HowManyLegs;
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return Ok("Nastąpił jakiś błąd");


        }

        // DELETE: api/Uzytkownik/5
        public IHttpActionResult Delete(string login)
        {
            var result = Database.Instance.Uzytkowniks.Where(x => x.login == login).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.Uzytkowniks.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
