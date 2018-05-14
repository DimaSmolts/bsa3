using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bsa3.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        // GET api/car
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "hello", "car" ,"controller"};
        }

        // GET api/car/{id}        
        [HttpGet("{id}")]
        public string GetOne(int id)
        {
            return $"value {id}";
        }

        // POST api/car
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }  

        // DELETE api/car/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }              
        
    }
}