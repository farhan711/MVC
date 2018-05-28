using MovieMix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMix.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberofStocks;
            GenreId = movie.Genre;
        }
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
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public int Id { get; }
        public string Name { get; }
        public DateTime ReleaseDate { get; private set; }
        public byte NumberInStock { get; }
        public byte GenreId { get; }
    }
}