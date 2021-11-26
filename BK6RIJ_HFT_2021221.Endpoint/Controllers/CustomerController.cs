using Microsoft.AspNetCore.Mvc;
using System;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BK6RIJ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic cl;

        public CustomerController(ICustomerLogic cl)
        {
            this.cl = cl;
        }

        // GET: /customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cl.ReadAll();
        }

        // GET /customer/3
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return cl.Read(id);
        }

        // POST /customer
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            cl.Create(value);
        }

        // PUT /customer
        [HttpPut]
        public void Put([FromBody] Customer value)
        {
            cl.Update(value);
        }

        // DELETE customer/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
