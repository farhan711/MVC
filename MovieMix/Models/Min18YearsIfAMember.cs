using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MovieMix.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipId == MembershipType.Unkown || customer.MembershipId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if(customer.DOB == null)
            {
                return new ValidationResult("Birthdate is Required");
            }
            var age = DateTime.Today.Year - customer.DOB.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer must be 18 years old or above");
        }
    }
}