using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string productname { get; set; }
        public int cost { get; set; }
        
        public int quantity { get; set; }
    }
}
