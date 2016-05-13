using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionIA.Models
{
    public class User
    {
        [Key]
        public int ID { set; get; }
        [Required(ErrorMessage = "you should enter your name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "you should enter password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        public string Role { set; get; }
        public string Image { set; get; }
        [Required(ErrorMessage = "you should enter your Email")]
        public string Email { set; get; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Advertise> Advertises { get; set; }
        public virtual ICollection<TempArticle> TempArticles { get; set; }
        public virtual ICollection<Favourate> favourites { get; set; }
    }
}