using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionIA.Models
{
    public class Advertise
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int ViewNo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorNAme { get; set; }
        public string AuthorRole { get; set; }
    }
}