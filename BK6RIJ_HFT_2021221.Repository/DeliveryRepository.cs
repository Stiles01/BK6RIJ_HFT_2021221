using BK6RIJ_HFT_2021221.Data;
using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Repository
{
    class DeliveryRepository : IDeliveryRepository
    {
        XYZDbContext db;

        public DeliveryRepository(XYZDbContext XYZDb)
        {
            db = XYZDb;
        }



        public void Create(Delivery delivery)
        {
            db.Deliveries.Add(delivery);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Delivery Read(int id)
        {
            return db.Deliveries.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Delivery> ReadAll()
        {
            return db.Deliveries;
        }

        public void Update(Delivery delivery)
        {
            var oldDelivery = Read(delivery.Id);
            oldDelivery.DeliveryDays = delivery.DeliveryDays;
            oldDelivery.Company = delivery.Company;
            db.SaveChanges();
        }
    }
}
