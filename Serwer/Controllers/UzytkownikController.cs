using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class UzytkownikController : ApiController
    {
        // GET: api/Uzytkownik
        public IHttpActionResult Get()
        {
            var result = Database.Instance.Uzytkowniks;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x=>new S_Uzytkownik(x)));
        }

        // GET: api/Uzytkownik/5
        public object Get(string login)
        {
            var result = Database.Instance.Uzytkowniks.Where(x => x.login == login);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x=>new S_Uzytkownik(x)));
        }

        // POST: api/Uzytkownik
        public IHttpActionResult Post([FromBody]S_Uzytkownik value)
        {
            try
            {
                Database.Instance.Uzytkowniks.InsertOnSubmit(S_Uzytkownik.ToUzytkownik(value));
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
