using Microsoft.AspNetCore.Http;
using BK6RIJ_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatisticController : Controller
    {
        //non-CRUD methods

        IOrderLogic ol;

        public StatisticController(IOrderLogic ol)
        {
            this.ol = ol;
        }

        // statistic/avgdeliverydaysbyproducts
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGDeliveryDaysByProducts()
        {
            return ol.AVGDeliveryDaysByProducts();
        }

        // statistic/countofproductsbycustomers
        [HttpGet]
        public IEnumerable<KeyValuePair<int, int>> CountOfProductsByCustomers()
        {
            return ol.CountOfProductsByCustomers();
        }

        // statistic/ordersfromaspecificcustomer/3
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<DateTime, string>> OrdersFromASpecificCustomer(int id)
        {
            return ol.OrdersFromASpecificCustomer(id);
        }

        // statistic/countofordersbycompanies
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountOfOrdersByCompanies()
        {
            return ol.CountOfOrdersByCompanies();
        }

        // statistic/orderinformationsafteradate/2021.07.01
        [HttpGet("{date}")]
        public IEnumerable<KeyValuePair<int, string>> OrderInformationsAfterADate(string date)
        {
            return ol.OrderInformationsAfterADate(date);
        }
    }
}
