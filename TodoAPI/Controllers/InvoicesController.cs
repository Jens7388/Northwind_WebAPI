using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind_WebAPI.Entities;
using Northwind_WebAPI.DataAccess;
namespace Northwind_WebAPI.TodoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoicesController: ControllerBase
    {
        [HttpGet("{customerId}")]
        public List<Invoice> GetAll(string customerId)
        {
            List<Invoice> invoices = new Repository().GetAllInvoices(customerId);
            return invoices;
        }
    }
}