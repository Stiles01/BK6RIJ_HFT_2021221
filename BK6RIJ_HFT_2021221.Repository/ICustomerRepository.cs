using System;
using System.Collections.Generic;
using BK6RIJ_HFT_2021221.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Repository
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Delete(int id);
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer customer);
    }
}
