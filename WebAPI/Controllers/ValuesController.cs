using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        Green02Entities db = new Green02Entities();
        public List<Plantes> GetListPlante()
        {
            return db.Plantes.ToList();
        }

        [HttpPost]
        public void AddPlante([FromBody]Plantes value)
        {
            db.Plantes.Add(value);
            db.SaveChanges();
        }


    //    // GET api/values
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/values/5
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/values
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/values/5
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/values/5
    //    public void Delete(int id)
    //    {
    //    }
    }
}
