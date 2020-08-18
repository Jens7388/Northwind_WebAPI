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
        [HttpGet("{isShipped}/{customerId}")]
        //Type true in the URL to display completed orders, type false for non-completed ones
        public List<Order> GetAll(bool isShipped, string customerID)
        {
                List<Order> orders = new Repository().GetAllOrders(customerID);
                List<Order> completedOrders = new List<Order>();
                List<Order> nonCompletedOrders = new List<Order>();
                foreach(Order order in orders)
                {
                    if(order.IsShipped)
                    {
                        completedOrders.Add(order);
                        
                    }
                    else
                    {
                        nonCompletedOrders.Add(order);
                    }
                }
                if(isShipped)
                {
                    return completedOrders;
                }
                else
                {
                    return nonCompletedOrders;
                }           
        }
    }
}