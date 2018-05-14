using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MovieMix.Models
{
    public class GenreN
    {

        public byte Id { get; set; }
        [Required]
        [StringLength(255)]

        public String Name { get; set; }


    }
}
