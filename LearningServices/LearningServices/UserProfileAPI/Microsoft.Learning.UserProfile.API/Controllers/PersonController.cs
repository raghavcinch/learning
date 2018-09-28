using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Learning.Core.DocumentDB;
using Microsoft.Learning.UserProfile.API.Shared;
using Microsoft.Learning.UserProfile.Manager;

namespace Microsoft.LearningServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Controller
    {

        private readonly IPersonManager personManager;

        public PersonController(IPersonManager personManager)
        {
            this.personManager = personManager;
        }


        [HttpGet]
        public IEnumerable<PersonContract> Get()
        {
            var query = personManager.GetAllPeople();
            System.Diagnostics.Trace.WriteLine(query.ToString());
            return query.ToList();
        }
        [HttpGet]
        [Route("FulltimeEmployees")]
        public IEnumerable<FullTimeEmployeeContract> GetFullTimeEmployees()
        {
            var query = personManager.GetAllFullTimeEmployees();
            System.Diagnostics.Trace.WriteLine(query.ToString());
            return query.ToList();
        }
        [HttpGet]
        [Route("MCTs")]
        public IEnumerable<MCTContract> GetMCTs()
        {
            var query = personManager.GetMCTs();
            System.Diagnostics.Trace.WriteLine(query.ToString());
            return query.ToList();
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Person")]
        public PersonContract Get(string id)
        {
            var person = personManager.GetAllPeople().Where(a => a.PUID == id).ToList().SingleOrDefault();
            return person;
        }
        // GET: api/Person/5
        [HttpGet]
        [Route("PersonProjected/{id}")]
        public JsonResult Get_Projected(string id)
        {
            var person = personManager.GetAllPeople().Where(a => a.PUID == id).ToList().SingleOrDefault();
            return Json(person);
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
