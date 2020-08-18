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
        [HttpGet("{customerId}")]
        public List<Order> GetAll(string customerID)
        {
            List<Order> orders = new Repository().GetAllOrders(customerID);
            return orders;
        }
    }
}