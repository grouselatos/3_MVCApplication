using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3_MVCApplication.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //Navigation property
        public virtual ICollection<Movie> Movies { get; set; }

    }
}