using System;
using System.Collections.Generic;
using BK6RIJ_HFT_2021221.Models;

namespace BK6RIJ_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestServices restService = new RestServices("http://localhost:9973");

            //CRUD methods of Order 
            var orders = restService.Get<Order>("order");
            var order5 = restService.GetSingle<Order>("order/5");
            restService.Post<Order>(new Order()
            {
                OrderDate = new DateTime(2021,12,06),
                CustomerId = 1,
                ProductId = 1,
                DeliveryId = 1
            }, "order");
            restService.Put<Order>(new Order()
            {
                OrderId = 21,
                OrderDate = new DateTime(2021, 12, 23),
                CustomerId = 1,
                ProductId = 1,
                DeliveryId = 1
            }, "order");
            restService.Delete(21, "order");

            //CRUD methods of Delivery
            var deliveries = restService.Get<Delivery>("delivery");
            var delivery2 = restService.GetSingle<Delivery>("delivery/2");
            restService.Post<Delivery>(new Delivery()
            {
                Company = "New POST",
                DeliveryDays = 120
            }, "delivery");
            restService.Put<Delivery>(new Delivery()
            {
                Id = 5,
                Company = "New POST",
                DeliveryDays = 12
            }, "delivery");
            restService.Delete(5, "delivery");

            //CRUD methods of Customer
            var customers = restService.Get<Customer>("customer");
            var customer3 = restService.GetSingle<Customer>("customer/3");
            restService.Post<Customer>(new Customer()
            {
                FirstName = "Varga",
                LastName = "Daniel"
            }, "customer");
            restService.Put<Customer>(new Customer()
            {
                Id = 5,
                FirstName = "Varga",
                LastName = "David"
            }, "customer");
            restService.Delete(5, "customer");

            //CRUD methods of Product
            var products = restService.Get<Product>("product");
            var product6 = restService.GetSingle<Product>("product/6");
            restService.Post<Product>(new Product()
            {
                Name = "PC",
                Price = 1200
            }, "product");
            restService.Put<Product>(new Product()
            {
                Id = 7,
                Name = "PC",
                Price = 120000
            }, "product");
            restService.Delete(7, "product");


            //non-CRUD methods
            var countofordersbyproducts = restService.Get<KeyValuePair<string, int>>("statistic/countofordersbyproducts");
            var countofproductsbycustomers = restService.Get<KeyValuePair<int, int>>("statistic/countofproductsbycustomers");
            var ordersfromaspecificcustomer = restService.Get<KeyValuePair<DateTime, string>>("statistic/ordersfromaspecificcustomer/2");
            var countofordersbycompanies = restService.Get<KeyValuePair<string, int>>("statistic/countofordersbycompanies");
            var orderinformationsafteradate = restService.Get<KeyValuePair<int, string>>("statistic/orderinformationsafteradate/2021.07.01");

            ;
           

           
        }
    }
}
