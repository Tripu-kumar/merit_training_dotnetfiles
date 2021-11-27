using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.data.Interface;
using ProductStore.data.Models;

namespace ProductStore.data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> products = new List<Product>()
        {
            new Product { Id = 101, productname = "pendrive", cost = 1000, quantity = 2 },
            new Product { Id = 102, productname = "laptop", cost = 2000, quantity = 1 }
        };
        public List<Product> getallproducts()
        {
            return products;
        }
        public Product getproductbyid(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }
    }
}
