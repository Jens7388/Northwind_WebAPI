using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind_WebAPI.DataAccess;
using Northwind_WebAPI.Entities;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        [HttpGet("completed/{customerId}")]
        public List<Order> GetCompletedOrders(string customerID)
        {
             return new Repository().GetAllCompletedOrders(customerID);
        }

        [HttpGet("pending/{customerId}")]
        public List<Order> GetNonCompletedOrders(string customerID)
        {
            return new Repository().GetAllNonCompletedOrders(customerID);
        }
    }
}