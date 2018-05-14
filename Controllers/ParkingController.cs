using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bsa3
{
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {

        // GET api/parking/money        
        [HttpGet("money")]
        public string GetMoney()
        {
            return "total money";
        }

        // GET api/parking/free      
        [HttpGet("free")]        
        public string GetFreePlaces()
        {
            return $"free places x out of {Settings.ParkingSpace} ";
        }

        // GET api/parking/busy  
        [HttpGet("busy")]        
        public string GetBusyPlaces()
        {
            return $"busy places x out of {Settings.ParkingSpace}";
        }
    }    
}