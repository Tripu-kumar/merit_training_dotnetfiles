using System;
using System.Collections.Generic;

#nullable disable

namespace contactwebapidb.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Message { get; set; }
    }
}
