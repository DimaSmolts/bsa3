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
        public double GetMoney()
        {
            Parking myPark = Parking.Instance;
            return myPark.balance;
        }

        // GET api/parking/free      
        [HttpGet("free")]        
        public int GetFreePlaces()
        {
            Parking myPark = Parking.Instance;            
            return (Settings.ParkingSpace-myPark.parkingLot.Count);
        }

        // GET api/parking/busy  
        [HttpGet("busy")]        
        public int GetBusyPlaces()
        {
            Parking myPark = Parking.Instance;            
            return (myPark.parkingLot.Count);
        }
    }    
}