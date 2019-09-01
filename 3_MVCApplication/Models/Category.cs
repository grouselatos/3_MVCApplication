using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3_MVCApplication.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        //navigation properties which represent the cardinality/relationship between classes
        public virtual ICollection<Movie> Movies { get; set; } //protimotero na prostheteis interface kai oxi concrete class

    }
}