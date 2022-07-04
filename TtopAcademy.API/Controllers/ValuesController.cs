﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TtopAcademy.API.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            return await Task.FromResult(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        public string Get(string id)
        {
            return id;
        }


        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}