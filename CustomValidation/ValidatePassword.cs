using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SimpleNote.Models;

namespace SimpleNote.CustomValidation
{
    public class ValidatePassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;
            if (user.Password != null)
            {
                Regex reg = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$");
                if (reg.IsMatch(user.Password))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Password should be at least 6 letters long "
                                                + "and contain at least one lowercase letter, "
                                                + "one uppercase letter, and one number.");
                }
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}