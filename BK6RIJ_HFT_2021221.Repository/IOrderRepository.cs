using System;
using System.Collections.Generic;
using BK6RIJ_HFT_2021221.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Repository
{
    interface IOrderRepository
    {
        void Create(Order order);
        void Delete(int id);
        Order Read(int id);
        IQueryable<Order> ReadAll();
        void Update(Order order);
    }
}
