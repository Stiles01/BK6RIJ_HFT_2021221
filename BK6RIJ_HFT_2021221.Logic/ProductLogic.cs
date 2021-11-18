using BK6RIJ_HFT_2021221.Models;
using BK6RIJ_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Logic
{
    public class ProductLogic : IProductLogic
    {
        IProductRepository productRepo;

        public ProductLogic(IProductRepository p)
        {
            productRepo = p;
        }

        public void Create(Product product)
        {
            if (product.Name == "")
            {
                throw new ArgumentNullException("Name cannot be empty!");
            }
            else if (product.Price <= 0)
            {
                throw new ArgumentOutOfRangeException("Price must be a positive number!");
            }
            productRepo.Create(product);
        }

        public void Delete(int id)
        {
            productRepo.Delete(id);
        }

        public Product Read(int id)
        {
            return productRepo.Read(id);
        }

        public IEnumerable<Product> ReadAll()
        {
            return productRepo.ReadAll();
        }

        public void Update(Product product)
        {
            productRepo.Update(product);
        }




    }
}
