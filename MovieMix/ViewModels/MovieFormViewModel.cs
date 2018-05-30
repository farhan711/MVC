using MovieMix.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMix.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreN> Genres { get; set; }
        public int Id { get; set; }

        public String Name { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Byte Genre { get; set; }
        public GenreN GenreN { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public byte NumberofStocks { get; set; }
         
        public String Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
       
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberofStocks = movie.NumberofStocks;
            Genre = movie.Genre;
        }
    }
}