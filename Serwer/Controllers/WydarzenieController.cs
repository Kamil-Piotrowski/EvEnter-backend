using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    [RoutePrefix("api/Wydarzenie")]
    public class WydarzenieController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = Database.Instance.Wydarzenies;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x=>new S_Wydarzenie(x)));
        }


        [Route("{id:int}")]
        public object Get(int id)
        {
            var result = Database.Instance.Wydarzenies.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Wydarzenie(x)));
        }

        [Route("organizowane-przeze-mnie/{login}")]
        public object Get(string login)
        {
            var result = Database.Instance.Wydarzenies.Where(x => x.login_organizatora == login);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Wydarzenie(x)));
        }

        [Route("moje-wydarzenia/{login}")]
        public object GetByAttendance(string login)
        {
            var result = Database.Instance.udzial_w_wydarzenius
                .Where(x => x.login_uczestnika == login)
                .Select(x => x.Wydarzenie).ToList();

            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Wydarzenie(x)));
        }

        [Route("add")]
        public IHttpActionResult Post([FromBody]Wydarzenie value)
        {
            try
            {
                Database.Instance.Wydarzenies.InsertOnSubmit((value));
                Database.Instance.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]Wydarzenie value)
        {
            var result = Database.Instance.Wydarzenies.Where(x => x.id == id).FirstOrDefault();
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
            var result = Database.Instance.Wydarzenies.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                Database.Instance.Wydarzenies.DeleteOnSubmit(result);
                Database.Instance.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
