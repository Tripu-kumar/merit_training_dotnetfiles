using System;
using System.Collections.Generic;


#nullable disable

namespace WebApidbwith2tables.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
       
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
