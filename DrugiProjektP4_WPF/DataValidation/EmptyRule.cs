using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugiProjektP4_WPF.DataValidation
{
    internal class EmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (string.IsNullOrEmpty(charString))
                return new ValidationResult(false, $"Pusty!!");

            return new ValidationResult(true, null);
        }
    }
}
