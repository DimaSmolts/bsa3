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
        public void Put(int id, [FromBody]string value)
        {
        }
		// GET api/Transactions        
        [HttpGet]
        public string GetTransactions()
        {
            return "GetTransactions";
        }

		// GET api/Transactions/LastMinute        
        [HttpGet("LastMinute")]
        public string GetTransactionsMinute()
        {
            return "GetTransactionsLastMinute (1)";
        }

		// GET api/Transactions/LastMinute/{id}        
        [HttpGet("LastMinute/{id}")]
        public string GetTransactionsLastMinute(int id)
        {
            return $"GetTransactionsLastMinute {id} (2)";
        }

    }
    
}