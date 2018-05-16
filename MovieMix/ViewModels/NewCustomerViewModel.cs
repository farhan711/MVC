using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieMix.Models;

namespace MovieMix.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}