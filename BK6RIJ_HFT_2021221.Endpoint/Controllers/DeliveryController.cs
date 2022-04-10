using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BK6RIJ_HFT_2021221.Endpoint.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BK6RIJ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        IDeliveryLogic dl;
        private readonly IHubContext<SinalRHub> hub;

        public DeliveryController(IDeliveryLogic dl, IHubContext<SinalRHub> hub)
        {
            this.dl = dl;
            this.hub = hub;
        }

        // GET: /delivery
        [HttpGet]
        public IEnumerable<Delivery> Get()
        {
            return dl.ReadAll();
        }

        // GET /delivery/3
        [HttpGet("{id}")]
        public Delivery Get(int id)
        {
            return dl.Read(id);
        }

        // POST /delivery
        [HttpPost]
        public void Post([FromBody] Delivery value)
        {
            dl.Create(value);
            hub.Clients.All.SendAsync("DeliveryCreated", value);
        }

        // PUT /delivery
        [HttpPut]
        public void Put([FromBody] Delivery value)
        {
            dl.Update(value);
            hub.Clients.All.SendAsync("DeliveryUpdated", value);
        }

        // DELETE delivery/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var one = dl.Read(id);
            dl.Delete(id);
            hub.Clients.All.SendAsync("DeliveryDeleted", one);
        }
    }
}
