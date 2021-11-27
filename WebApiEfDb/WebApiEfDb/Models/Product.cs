using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEfDb.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
    }
}
