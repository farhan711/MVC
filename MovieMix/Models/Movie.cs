using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMix.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public String Name { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Byte Genre { get; set; }
        public GenreN GenreN { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        public byte NumberofStocks { get; set; }
    }
}