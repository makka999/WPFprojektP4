using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrugiProjektP4_WPF
{
    public class MaxCharacterRule : ValidationRule
    {
        public int MaxCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;


            if (charString.Length > MaxCharacters)
                return new ValidationResult(false, $"Maksymalna ilosc {MaxCharacters} znakow.");


            return new ValidationResult(true, null);
        }
    }
}
