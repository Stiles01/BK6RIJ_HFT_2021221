using BK6RIJ_HFT_2021221.Models;
using BK6RIJ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public class DeliveryLogic : IDeliveryLogic
    {
        IDeliveryRepository deliveryRepo;

        public DeliveryLogic(IDeliveryRepository delivery)
        {
            deliveryRepo = delivery;
        }


        public void Create(Delivery delivery)
        {
            if (delivery.Company == "")
            {
                throw new ArgumentNullException("Empty name is not allowed!");
            }
            else if (delivery.DeliveryDays <= 0)
            {
                throw new ArgumentOutOfRangeException("Delivery days cannot be negative!");
            }
            deliveryRepo.Create(delivery);
        }

        public void Delete(int id)
        {
            deliveryRepo.Delete(id);
        }

        public Delivery Read(int id)
        {
            return deliveryRepo.Read(id);
        }

        public IEnumerable<Delivery> ReadAll()
        {
            return deliveryRepo.ReadAll();
        }

        public void Update(Delivery delivery)
        {
            deliveryRepo.Update(delivery);
        }


    }
}
