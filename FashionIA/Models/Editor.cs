using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionIA.Models
{
    public class Editor
    {
        [Key]
        public int ID { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public string Role { set; get; }
        public string Image { set; get; }
        public string Email { set; get; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Advertise> Advertises { get; set; }
        public virtual ICollection<TempArticle> TempArticles { get; set; }
        public virtual ICollection<Favourate> favourites { get; set; }
    }
}