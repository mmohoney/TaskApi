using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebLibrary.Areas.CheckLists.Controllers
{
    public class CheckListController : ApiController
    {
        // GET: api/CheckList
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CheckList/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CheckList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckList/5
        public void Delete(int id)
        {
        }
    }
}
