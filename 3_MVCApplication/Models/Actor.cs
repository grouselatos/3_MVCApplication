using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3_MVCApplication.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vale kati nte!")]
        public string Name { get; set; }
        [Range(1, 150, ErrorMessage ="Vale ena logiko orio ilkias!")]
        public int Age { get; set; }

        //Navigation Properties
        public virtual ICollection<Movie> Movies { get; set; }
    }
}