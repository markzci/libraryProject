using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MarkusLib.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string summary { get; set; }
        public List<Book> Books { get; set; }
    }
}
