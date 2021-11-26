using Microsoft.AspNetCore.Mvc;
using BK6RIJ_HFT_2021221.Logic;
using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BK6RIJ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductLogic pl;

        public ProductController(IProductLogic pl)
        {
            this.pl = pl;
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
        }

        // PUT /product
        [HttpPut]
        public void Put([FromBody] Product value)
        {
            pl.Update(value);
        }

        // DELETE product/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
