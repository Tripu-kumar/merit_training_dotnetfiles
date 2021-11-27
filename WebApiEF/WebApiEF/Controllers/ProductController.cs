using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiEF.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEF.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductDbContext _context;
        public ProductController(ProductDbContext con)
        {
            _context = con;
        }
        
        
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(x=>x.Id == id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _context.Products.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == id);
            if(prod != null)
            {
                _context.Entry<Product>(prod).CurrentValues.SetValues(value);
                _context.SaveChanges();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == id);
            if (prod != null)
            {
                _context.Products.Remove(prod);
                _context.SaveChanges();
            }
        }
    }
}
