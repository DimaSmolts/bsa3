using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bsa3.Controllers
{
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {

        // GET api/parking/{id}        
        [HttpGet("money")]
        public string GetMoney()
        {
            return "total money";
        }

        // GET api/parking/free      
        //[Route("api/[controller]/free")]  
        [HttpGet("free")]        
        public string GetFreePlaces()
        {
            return $"free places ";
        }

        // GET api/parking/busy
        //[Route("api/[controller]/busy")]  
        [HttpGet("busy")]        
        public string GetBusyPlaces()
        {
            return $"busy places";
        }
    }    
}