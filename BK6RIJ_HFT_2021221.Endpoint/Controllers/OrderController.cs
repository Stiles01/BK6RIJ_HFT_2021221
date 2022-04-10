using Microsoft.AspNetCore.Mvc;
using BK6RIJ_HFT_2021221.Models;
using BK6RIJ_HFT_2021221.Logic;
using System;
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
    public class OrderController : ControllerBase
    {
        IOrderLogic ol;
        private readonly IHubContext<SinalRHub> hub;

        public OrderController(IOrderLogic ol, IHubContext<SinalRHub> hub)
        {
            this.ol = ol;
            this.hub = hub;
        }

        // GET: /order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return ol.ReadAll();
        }

        // GET /order/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return ol.Read(id);
        }

        // POST /order
        [HttpPost]
        public void Post([FromBody] Order value)
        {
            ol.Create(value);
            hub.Clients.All.SendAsync("OrderCreated", value);
        }

        // PUT /order
        [HttpPut]
        public void Put([FromBody] Order value)
        {
            ol.Update(value);
            hub.Clients.All.SendAsync("OrderUpdated", value);
        }

        // DELETE order/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var one = ol.Read(id);
            ol.Delete(id);
            hub.Clients.All.SendAsync("OrderDeleted", one);
        }
    }
}
