using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DrugiProjektP4_WPF.DataValidation
{
    public class DataRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (!Regex.IsMatch(charString,"^[0-9]{1,2}\\.[0-9]{1,2}\\.[0-9]{4}$"))
                return new ValidationResult(false, $"DD.MM.RRRR"); ;

            return new ValidationResult(true, null);
        }
    }
}
