using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(10)]
        public string Title { get; set; }
    }
}