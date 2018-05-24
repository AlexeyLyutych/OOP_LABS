using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace Zoo.Validation
{
    public class PhoneValidator : ValidationRule
    {
        private string _regex = @"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (!Regex.IsMatch(value.ToString(), _regex))
                    return new ValidationResult(false, "");
            }
            return ValidationResult.ValidResult;
        }
    }

}
