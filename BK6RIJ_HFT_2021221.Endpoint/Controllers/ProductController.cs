using Microsoft.AspNetCore.Mvc;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Models;
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
    public class ProductController : ControllerBase
    {
        IProductLogic pl;
        private readonly IHubContext<SinalRHub> hub;

        public ProductController(IProductLogic pl, IHubContext<SinalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
        }

        // GET: /product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return pl.ReadAll();
        }

        // GET /product/3
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return pl.Read(id);
        }

        // POST /product
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            pl.Create(value);
            hub.Clients.All.SendAsync("ProductCreated", value);
        }

        // PUT /product
        [HttpPut]
        public void Put([FromBody] Product value)
        {
            pl.Update(value);
            hub.Clients.All.SendAsync("ProductUpdated", value);
        }

        // DELETE product/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var one = pl.Read(id);
            pl.Delete(id);
            hub.Clients.All.SendAsync("ProductDeleted", one);
        }
    }
}
