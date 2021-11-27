using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public List<Product> products = new List<Product>()
        {
            new Product { Id = 101, productname = "pendrive", cost = 1000, quantity = 2 },
            new Product { Id = 102, productname = "laptop", cost = 2000, quantity = 1 }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Product>> getallproducts()
        {
            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> getproductbyid(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
                if (product == null)
            {
                return NotFound();
            }
            return product;
        }
    }
}
