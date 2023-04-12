using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.Model.Custom_Validators
{
    public class CustomEmailValidator: ValidationAttribute
    {
        public string AttributeText { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value.ToString().Length != 0)
            {

                String[] str = value.ToString().Split('@');
                int len = str.Length;

                if (str[len-1] != null && str[len-1].ToLower() == "gmail.com")
                {
                    return null;
                }
                else
                {
                    return new ValidationResult($"Domain must be gmail.com",
                           new[] { validationContext.MemberName });
                }
            }

            else
            {
                return new ValidationResult($"Domain must be gmail.com",
                       new[] { validationContext.MemberName });
            }
        }
    }
}
