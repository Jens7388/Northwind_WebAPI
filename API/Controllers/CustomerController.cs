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
    public class CustomerController: ControllerBase
    {
        [HttpGet]
        public List<Customer> GetAll()
        {
            return new Repository().GetAllCustomers();
        }
    }
}