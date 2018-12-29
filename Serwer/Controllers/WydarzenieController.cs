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
            DBDataContext db = new DBDataContext();
            var result = db.Wydarzenies;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x=>new S_Wydarzenie(x)));
        }


        [Route("{id:int}")]
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Wydarzenies.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Wydarzenie(x)));
        }

        [Route("organizowane-przeze-mnie/{login}")]
        public object Get(string login)
        {
            DBDataContext db = new DBDataContext();
            var result = db.Wydarzenies.Where(x => x.login_organizatora == login);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Wydarzenie(x)));
        }

        [Route("moje-wydarzenia/{login}")]
        public object GetByAttendance(string login)
        {
            DBDataContext db = new DBDataContext();
            var result = db.udzial_w_wydarzenius
                .Where(x => x.login_uczestnika == login)
                .Select(x => x.Wydarzenie).ToList();

            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Wydarzenie(x)));
        }
        [Route("proponowane-wydarzenia/{login}")]
        public object GetProposed(string login)
        {
            DBDataContext db = new DBDataContext();
            List<Wydarzenie> allEvents = db.udzial_w_wydarzenius.Select(x => x.Wydarzenie).ToList();
            List<int> myEventsIds = db.udzial_w_wydarzenius.Where(x => x.login_uczestnika == login).Select(x => x.Wydarzenie).Select(x=>x.id).ToList();
            List<Wydarzenie> result = new List<Wydarzenie>();
            
           foreach(Wydarzenie w in allEvents)
            {
                if (!myEventsIds.Contains(w.id))
                {
                    result.Add(w);
                }
            }
           

            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_Wydarzenie(x)));
        }

        [Route("add")]
        public IHttpActionResult Post([FromBody]Wydarzenie value)
        {
            DBDataContext db = new DBDataContext();
            try
            {

                int id;
                var ids = db.Wydarzenies.Select(x => x.id);
                if (ids.Count() > 0)
                    id = ids.Max() + 1;
                else
                    id = 1;
                Wydarzenie w = new Wydarzenie {
                    id = id,
                    wysokosc = value.wysokosc,
                    szerokosc = value.szerokosc,
                    data_poczatku = value.data_poczatku,
                    data_konca = value.data_konca,
                    login_organizatora = value.login_organizatora,
                    nazwa_wydarzenia = value.nazwa_wydarzenia
                };

                db.Wydarzenies.InsertOnSubmit((w));
                db.SubmitChanges();

                udzial_w_wydarzeniu u = new udzial_w_wydarzeniu { Wydarzenie = w, data_dolaczenia = DateTime.Now, login_uczestnika = value.login_organizatora };
                db.udzial_w_wydarzenius.InsertOnSubmit(u);
                db.SubmitChanges();
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
            DBDataContext db = new DBDataContext();
            var result = db.Wydarzenies.Where(x => x.id == id).FirstOrDefault();
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
            var result = db.Wydarzenies.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                db.Wydarzenies.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
