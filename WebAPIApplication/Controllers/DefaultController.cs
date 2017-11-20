using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Context;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class DefaultController : ApiController
    {
        //Creating Instance of DatabaseContext class  
        private DataBaseContext db = new DataBaseContext();

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                    var result = from developer in db.Developers
                                 select new
                                 {
                                     developer.DeveloperId,
                                     developer.FirstName,
                                     developer.LastName,
                                     developer.ContactPhone,
                                     developer.Email,
                                     developer.DayBirth,
                                     developer.Address,
                                     developer.Stacks,
                                     developer.WebTechnologies,
                                     developer.Comments,
                                 };
                    return Ok(result);
            }
            catch(Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        // GET api/<controller>/
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = db.Developers.Where(x => x.DeveloperId == id);
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]Developer value)
        {
            try
            {
                db.Developers.Add(value);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var remove = db.Developers.First(x=> x.DeveloperId == id);
                db.Developers.Remove(remove);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
    }
}