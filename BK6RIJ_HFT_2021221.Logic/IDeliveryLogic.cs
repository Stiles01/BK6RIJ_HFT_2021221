using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public interface IDeliveryLogic
    {
        void Create(Delivery delivery);
        void Delete(int id);
        Delivery Read(int id);
        IEnumerable<Delivery> ReadAll();
        void Update(Delivery delivery);
    }
}
