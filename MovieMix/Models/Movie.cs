﻿using System;
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
        public Byte Genre { get; set; }
        public GenreN GenreN { get; set; }
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
        public byte NumberofStocks { get; set; }
    }
}