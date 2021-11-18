using BK6RIJ_HFT_2021221.Models;
using BK6RIJ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        ICustomerRepository customerRepo;

        public CustomerLogic(ICustomerRepository customer)
        {
            customerRepo = customer;
        }


        public void Create(Customer customer)
        {
            if (customer.FirstName == "" || customer.LastName == "")
            {
                throw new ArgumentNullException();
            }
            customerRepo.Create(customer);
        }

        public void Delete(int id)
        {
            customerRepo.Delete(id);
        }

        public Customer Read(int id)
        {
            return customerRepo.Read(id);
        }

        public IQueryable<Customer> ReadAll()
        {
            return customerRepo.ReadAll();
        }

        public void Update(Customer customer)
        {
            customerRepo.Update(customer);
        }
    }
}
