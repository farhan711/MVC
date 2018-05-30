using MovieMix.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMix.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribeToNewsletter { get; set; }

        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }

        //public byte MembershipId { get; set; }
    }
}