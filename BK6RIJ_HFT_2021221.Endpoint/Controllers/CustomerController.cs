using Microsoft.AspNetCore.Mvc;
using System;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BK6RIJ_HFT_2021221.Endpoint.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BK6RIJ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic cl;
        private readonly IHubContext<SinalRHub> hub;

        public CustomerController(ICustomerLogic cl, IHubContext<SinalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("CustomerCreated", value);
        }

        // PUT /customer
        [HttpPut]
        public void Put([FromBody] Customer value)
        {
            cl.Update(value);
            hub.Clients.All.SendAsync("CustomerUpdated", value);
        }

        // DELETE customer/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var one = cl.Read(id);
            cl.Delete(id);
            hub.Clients.All.SendAsync("CustomerDeleted", one);
        }
    }
}
