using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionIA.Models
{
    public class Feedback
    {

        [Key]
        public int VistorId { get; set; }
        [Required(ErrorMessage = "you should enter your Name")]
        public string VistorName { get; set; }
        [Required(ErrorMessage = "you should enter your Email")]
        public string VistorEmail { get; set; }
        [Required(ErrorMessage = "write your feedback please")]
        public string Comment { get; set; }
    }
}