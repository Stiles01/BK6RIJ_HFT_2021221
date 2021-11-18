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
            Type t = order.OrderDate.GetType();
            if (t.Equals(typeof(DateTime)))
            {
                throw new ArgumentException();
            }
        }

        public void Delete(int id)
        {
            orderRepo.Delete(id);
        }

        public Order Read(int id)
        {
            return orderRepo.Read(id);
        }

        public IQueryable<Order> ReadAll()
        {
            return orderRepo.ReadAll();
        }

        public void Update(Order order)
        {
            orderRepo.Update(order);
        }


        //non-CRUD
    }
}
