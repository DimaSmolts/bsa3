using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace bsa3
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {

        // PUT api/Transactions/5
        [HttpPut("{id}")]
        public void Put([FromBody]T t)
        {
            Parking myPark = Parking.Instance;
            Console.WriteLine($"{t.id}  {t.sum}");
            myPark.Recharge(t.id,t.sum);
        }
		// GET api/Transactions        
        [HttpGet]
        public List<string> GetTransactions()
        {
            Parking myPark = Parking.Instance;
            return myPark.LogFileInPut();
        }

		// GET api/Transactions/LastMinute        
        [HttpGet("LastMinute")]
        public List<string> GetTransactionsMinute()
        {
           Parking myPark = Parking.Instance;
           
           return myPark.DisplayTransactions();


            //return "GetTransactionsLastMinute (1)";
        }

		// GET api/Transactions/LastMinute/{id}        
        [HttpGet("LastMinute/{id}")]
        public List<string> GetTransactionsLastMinute(int id)
        {
            Parking myPark = Parking.Instance;            
             return myPark.DisplayOneTransactions(id);
            //return $"GetTransactionsLastMinute {id} (2)";
        }

    }


    public class T
    {
        public int id{get;set;}
        public double sum{get;set;}

    }
    
}