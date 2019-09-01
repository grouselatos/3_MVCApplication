using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace _3_MVCApplication.Models
{
    public class Movie
    {
        //edw deineis mia arxikh timh sto icollection attribute.
        public Movie()
        {
            Actors = new HashSet<Actor>(); // to hashset einai san optimised list gia databases
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        public bool? Watched { get; set; } // the question mark allows the entry to have null as value

        //Navigation Properties

        //foreign Key gia th sysxetish, mpainei automata me name pairing(otan to onoma einai idio mono) h data annotation
        [ForeignKey("Category")]
        public string Genre { get; set; }
        public virtual Category Category { get; set; } //virtual is for lazy-loading aka it brings selected items back and not everything from database to RAM
        //foreign Key gia th sysxetish
        [DisplayName("Director")]
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}