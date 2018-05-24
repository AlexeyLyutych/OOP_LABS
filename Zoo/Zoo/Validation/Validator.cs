using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace Zoo.Validation
{
    public class NameValidator : ValidationRule
    {
        private string _regex = @"^[\sа-яА-ЯёЁa-zA-Z]+$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (!Regex.IsMatch(value.ToString(), _regex))
                    return new ValidationResult(false, "Поле не должно содержать цифры");
            }
            return ValidationResult.ValidResult;
        }
    }
    
}
