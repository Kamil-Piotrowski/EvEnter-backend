﻿using Serwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serwer.Controllers
{
    public class Ocena_WspoluczestnikaController : ApiController
    {
        public IHttpActionResult Get()
        {
            DBDataContext db = new DBDataContext();
            var result = db.ocena_wspoluczestnikas;
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_ocena_wspoluczestnika(x)));
        }

        // GET: api/User/5
        public object Get(int id)
        {
            DBDataContext db = new DBDataContext();
            var result = db.ocena_wspoluczestnikas.Where(x => x.id == id);
            if (result == null)
                return NotFound();
            return Ok(result.Select(x => new S_ocena_wspoluczestnika(x)));
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]ocena_wspoluczestnika value)
        {
            DBDataContext db = new DBDataContext();
            try
            {
                db.ocena_wspoluczestnikas.InsertOnSubmit((value));
                db.SubmitChanges();
                return Ok();
            }
            catch
            {
                return Ok("Niestety nastąpił błąd");
            }


        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]ocena_wspoluczestnika value)
        {
            DBDataContext db = new DBDataContext();
            var result = db.ocena_wspoluczestnikas.Where(x => x.id == id).FirstOrDefault();
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
            var result = db.ocena_wspoluczestnikas.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                db.ocena_wspoluczestnikas.DeleteOnSubmit(result);
                db.SubmitChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
