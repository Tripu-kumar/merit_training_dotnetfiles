using System;
using System.Collections.Generic;


#nullable disable

namespace WebApidbwith2tables.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        
        public virtual Customer Customer { get; set; }
    }
}
