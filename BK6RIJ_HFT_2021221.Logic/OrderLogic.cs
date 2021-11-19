using BK6RIJ_HFT_2021221.Models;
using BK6RIJ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public class OrderLogic : IOrderLogic
    {
        IOrderRepository orderRepo;

        public OrderLogic(IOrderRepository order)
        {
            orderRepo = order;
        }


        public void Create(Order order)
        {
            orderRepo.Create(order);
        }

        public void Delete(int id)
        {
            orderRepo.Delete(id);
        }

        public Order Read(int id)
        {
            return orderRepo.Read(id);
        }

        public IEnumerable<Order> ReadAll()
        {
            return orderRepo.ReadAll();
        }

        public void Update(Order order)
        {
            orderRepo.Update(order);
        }


        //non-CRUD


        public IEnumerable<KeyValuePair<string, double>> AVGDeliveryDaysByProducts()
        {
            return from x in orderRepo.ReadAll()
                   group x by x.Product.Name into grouped
                   select new KeyValuePair<string, double>
                   (grouped.Key, grouped.Average(x => x.Delivery.DeliveryDays));
        }

        public IEnumerable<KeyValuePair<int, int>> CountOfProductsByCustomers()
        {
            return from x in orderRepo.ReadAll()
                   group x by x.Customer.Id into grouped
                   select new KeyValuePair<int, int>
                   (grouped.Key, grouped.Select(x => x.Product.Name).Count());
        }

        public IEnumerable<KeyValuePair<DateTime, string>> OrdersFromASpecificCustomer(int id)
        {
            return from x in orderRepo.ReadAll()
                   where x.Customer.Id == id
                   orderby x.OrderDate
                   select new KeyValuePair<DateTime, string>
                   (
                       x.OrderDate,
                       x.Product.Name
                   );

        }

        public IEnumerable<KeyValuePair<string, int>> CountOfOrdersByCompanies()
        {
            return from x in orderRepo.ReadAll()
                   group x by x.Delivery.Company into grouped
                   select new KeyValuePair<string, int>
                   (grouped.Key, grouped.Select(x => x.OrderDate).Count());
        }

        public IEnumerable<KeyValuePair<int, string>> OrderInformationsAfterADate(string date)
        {
            DateTime orderDate = DateTime.Parse(date);
            return from x in orderRepo.ReadAll()
                   where x.OrderDate > orderDate
                   orderby x.OrderDate
                   select new KeyValuePair<int, string>
                   (
                       x.OrderId,
                       $"{x.OrderDate.ToShortDateString()} - {x.Customer.FirstName} {x.Customer.LastName}: {x.Product.Name} {x.Product.Price}/piece ".ToString() +
                       $"(Delivery: {x.Delivery.Company}-{x.Delivery.DeliveryDays})".ToString()
                   );
        }
    }
}
