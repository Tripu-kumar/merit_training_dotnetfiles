using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db2WebApplication.Models
{
    public class Author
    {
        [Key]
        public int authorid { get; set; }
        public string authorname { get; set; }
        public int pubyear { get; set; }

        public Book book { get; set; }
        [ForeignKey("bookid")]
        public int Bookid
        {
            get;set;
        }
    }
}
