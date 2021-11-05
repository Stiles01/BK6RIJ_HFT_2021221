using System;
using System.Collections.Generic;
using BK6RIJ_HFT_2021221.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Repository
{
    interface IDeliveryRepository
    {
        void Create(Delivery delivery);
        void Delete(int id);
        Delivery Read(int id);
        IQueryable<Delivery> ReadAll();
        void Update(Delivery delivery);
    }
}
