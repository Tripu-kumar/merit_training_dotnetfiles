using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db2WebApplication.Models
{
    public class Book
    { 
        [Key]
        public int bookid { get; set; }
        public string bookname { get; set; }

        public ICollection<Author> authors { get; set; } = new List<Author>();


    }
}
