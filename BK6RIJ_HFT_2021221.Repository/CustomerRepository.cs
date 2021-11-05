using BK6RIJ_HFT_2021221.Data;
using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Repository
{
    class CustomerRepository : ICustomerRepository
    {
        XYZDbContext db;

        public CustomerRepository(XYZDbContext XYZDb)
        {
            db = XYZDb;
        }


        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
        }

        public Customer Read(int id)
        {
            return db.Customers.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Customer> ReadAll()
        {
            return db.Customers;
        }

        public void Update(Customer customer)
        {
            var oldCustomer = Read(customer.Id);
            oldCustomer.LastName = customer.LastName;
            oldCustomer.FirstName = customer.FirstName;
            db.SaveChanges();
        }
    }
}
