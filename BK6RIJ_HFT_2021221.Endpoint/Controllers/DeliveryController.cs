using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Models;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BK6RIJ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        IDeliveryLogic dl;

        public DeliveryController(IDeliveryLogic dl)
        {
            this.dl = dl;
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
        }

        // PUT /delivery
        [HttpPut]
        public void Put([FromBody] Delivery value)
        {
            dl.Update(value);
        }

        // DELETE delivery/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dl.Delete(id);
        }
    }
}
