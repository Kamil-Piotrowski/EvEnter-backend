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
            DBDataContext db = new DBDataContext();
            var result = db.Uzytkowniks;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Uzytkownik(x)));
        }

        // GET: api/Uzytkownik/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Uzytkowniks.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Uzytkownik(x)));
        }
        [Route("login/{login}")]
        public IHttpActionResult Get(string login)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Uzytkowniks.Where(x => x.login == login);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Uzytkownik(x)));
        }

        [Route("add")]
        public IHttpActionResult Post([FromBody]Uzytkownik value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.Uzytkowniks.InsertOnSubmit(value);
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Unauthorized();
            }


        }
        [Route("start")]
        public IHttpActionResult AuthenticateUser([FromBody]Uzytkownik value)
        {
            DBDataContext db = new DBDataContext();
            if (db.Uzytkowniks.Where(x => x.login == value.login && x.skrot_hasla == value.skrot_hasla).Count() > 0)
                return Ok();
            else return Unauthorized();
        }

        [Route("update/login/{login}")]
        public IHttpActionResult Put(string login, [FromBody]Uzytkownik value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Uzytkowniks.Where(x => x.login == login).FirstOrDefault();
            if (result != null)
            {
                
                result.imie = value.imie;
                result.nazwisko = value.nazwisko;
                
                result.data_urodzenia = value.data_urodzenia;
                result.nr_telefonu = value.nr_telefonu;
                
                db.SubmitChanges();
                return Ok();
            }
            return Ok("Nastąpił jakiś błąd");


        }

        // DELETE: api/Uzytkownik/5
        public IHttpActionResult Delete(string login)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Uzytkowniks.Where(x => x.login == login).FirstOrDefault();
            if (result != null)
            {
                db.Uzytkowniks.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
