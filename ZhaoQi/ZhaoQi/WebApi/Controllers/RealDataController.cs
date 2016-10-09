using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ZhaoQi.Web.Core.Business;

namespace ZhaoQi.WebApi.Controllers
{
    public class RealDataController : ApiController
    {
        private BllRealData bll = new BllRealData();


        // GET api/realdata
        public string Get()
        {
            var returnModels = bll.Query(null);
            var returnValues = new Hashtable();
            foreach (var model in returnModels)
            {
                returnValues.Add(model.Tag + int.Parse(model.ProjectId).ToString("00"), model);
            }

            return JsonConvert.SerializeObject(returnValues);
        }

        // GET api/realdata/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/realdata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/realdata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/realdata/5
        public void Delete(int id)
        {
        }
    }
}
