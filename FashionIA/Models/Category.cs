using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionIA.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Advertise> Advertises { get; set; }
        public virtual ICollection<Product> products { get; set; }
        public virtual ICollection<TempArticle> TempArticles { get; set; }

    }
}