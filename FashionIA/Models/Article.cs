using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionIA.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public DateTime Date { get; set; }
        public int ViewNo { get; set; }
        [Required(ErrorMessage = "you should enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "you should write a content for your article")]
        public string Content { get; set; }
        public Feild feild { get; set; }
        public string AuthorNAme { get; set; }
        public string AuthorRole { get; set; }

    }
    public enum Feild
    {
       Design,Brands,Trends, Beauty, Fashion_Ideas, Fashion, SportStyle, Casual, Classic
    }
}