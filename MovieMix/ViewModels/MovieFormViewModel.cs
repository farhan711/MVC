using MovieMix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMix.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreN> Genres { get; set; }
        public Movie Movie { get; set; }
        public String Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                {
                    return "Edit Movie";
                }
                return "New Movie";
            }
        }
    }
}