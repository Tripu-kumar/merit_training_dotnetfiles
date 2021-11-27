using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string productname { get; set; }
        public int cost { get; set; }

        public int quantity { get; set; }
    }
}
