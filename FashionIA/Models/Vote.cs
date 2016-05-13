using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionIA.Models
{
    public class Vote
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Result { get; set; }
    }
}