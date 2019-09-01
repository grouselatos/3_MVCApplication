using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3_MVCApplication.Models;

namespace _3_MVCApplication.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }
        public List<int> _selectedActors;
        public List<int> SelectedActors
        {
            get
            {
                if (_selectedActors == null)
                {
                    _selectedActors = Movie.Actors.Select(x => x.Id).ToList();
                }
                return _selectedActors;
            }

            set
            {
                _selectedActors = value;
            }
        }
    }
}