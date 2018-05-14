using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bsa3
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        // GET api/car
        [HttpGet]
        public List<Car> GetAll()
        {
            Parking myPark = Parking.Instance;
            return myPark.parkingLot;
        }

        // GET api/car/{id}        
        [HttpGet("{id}")]
        public Car GetOne(int id)
        {
            Parking myPark = Parking.Instance;
            return myPark.parkingLot[id];
        }

        // POST api/car
        [HttpPost]
        public void Post([FromBody]Car temp)
        {
            Parking myPark = Parking.Instance;
            myPark.AddCar(temp);
        }  

        // DELETE api/car/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Parking myPark = Parking.Instance;
            myPark.DeleteCar(id);
        }              
        
    }
}