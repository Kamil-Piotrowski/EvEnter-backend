using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    [RoutePrefix("api/udzial")]
    public class Udzial_W_WydarzeniuController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.udzial_w_wydarzenius;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_udzial_w_wydarzeniu(x)));
        }

        [Route("{id:int}")]
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.udzial_w_wydarzenius.Where(x => x.id_wydarzenia == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_udzial_w_wydarzeniu(x)));
        }

        [Route("add")]
        public IHttpActionResult Post([FromBody]udzial_w_wydarzeniu value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.udzial_w_wydarzenius.InsertOnSubmit((value));
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]udzial_w_wydarzeniu value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.udzial_w_wydarzenius.Where(x => x.id_wydarzenia == id).FirstOrDefault();
            if (result != null)
            {
                //result.Name = value.Name;
                //result.HowManyLegs = value.HowManyLegs;
                db.SubmitChanges();
                return Ok();
            }
            return Ok("Nastąpił jakiś błąd");


        }

        [Route("delete/{EventIdDashLogin}")]
        public IHttpActionResult Delete(string EventIdDashLogin)
        {


            int dashIndex = EventIdDashLogin.IndexOf("-");
            int EventId = int.Parse(EventIdDashLogin.Substring(0, dashIndex));
            string Login = EventIdDashLogin.Substring(dashIndex + 1, EventIdDashLogin.Length - 1 - EventId.ToString().Length);




            DBDataContext db = new DBDataContext();
            var result = db.udzial_w_wydarzenius.Where(x => x.id_wydarzenia == EventId && x.login_uczestnika == Login).FirstOrDefault();
            if (result != null)
            {
                db.udzial_w_wydarzenius.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
