using BK6RIJ_HFT_2021221.Data;
using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Repository
{
    public class OrderRepository : IOrderRepository
    {
        XYZDbContext db;
        public OrderRepository(XYZDbContext XYZDb)
        {
            db = XYZDb;
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Order Read(int id)
        {
            return db.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public IQueryable<Order> ReadAll()
        {
            return db.Orders;
        }

        public void Update(Order order)
        {
            var oldOrder = Read(order.OrderId);
            oldOrder.OrderDate = order.OrderDate;
            db.SaveChanges();
        }
    }
}
