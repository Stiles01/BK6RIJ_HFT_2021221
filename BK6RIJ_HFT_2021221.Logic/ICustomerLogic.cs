using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer customer);
        void Delete(int id);
        Customer Read(int id);
        IEnumerable<Customer> ReadAll();
        void Update(Customer customer);
    }
}
