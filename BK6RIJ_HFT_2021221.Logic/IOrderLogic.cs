using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public interface IOrderLogic
    {
        void Create(Order order);
        void Delete(int id);
        Order Read(int id);
        IEnumerable<Order> ReadAll();
        void Update(Order order);

        //non-CRUD

        IEnumerable<KeyValuePair<string, double>> AVGDeliveryDaysByProducts();

        IEnumerable<KeyValuePair<int, int>> CountOfProductsByCustomers();

        IEnumerable<KeyValuePair<DateTime, string>> OrdersFromASpecificCustomer(int id);

        IEnumerable<KeyValuePair<string, int>> CountOfOrdersByCompanies();

        IEnumerable<KeyValuePair<int, string>> OrderInformationsAfterADate(string date);
    }
}
