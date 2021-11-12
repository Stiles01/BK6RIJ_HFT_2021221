using System;
using BK6RIJ_HFT_2021221.Data;
using BK6RIJ_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK6RIJ_HFT_2021221.Repository
{
    public class ProductRepository : IProductRepository
    {
        XYZDbContext db;
        public ProductRepository(XYZDbContext XYZDb)
        {
            db = XYZDb;
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Product Read(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> ReadAll()
        {
            return db.Products; 
        }

        public void Update(Product product)
        {
            var oldProduct = Read(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            db.SaveChanges();
        }
    }
}
