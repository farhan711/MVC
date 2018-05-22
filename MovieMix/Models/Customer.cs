﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMix.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribeToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }


        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }
       

        public byte MembershipId { get; set; }

    }
}