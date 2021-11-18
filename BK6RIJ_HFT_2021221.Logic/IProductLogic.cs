using BK6RIJ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public interface IProductLogic
    {
        void Create(Product product);
        void Delete(int id);
        Product Read(int id);
        IEnumerable<Product> ReadAll();
        void Update(Product product);
    }
}
