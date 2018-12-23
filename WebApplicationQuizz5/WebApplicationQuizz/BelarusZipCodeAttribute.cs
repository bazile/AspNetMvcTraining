using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplicationQuizz
{
    public class BelarusZipCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string zip = value as string;
            if (zip == null || string.IsNullOrWhiteSpace(zip))
            {
                ErrorMessage = "Не заполнен";
                return false;
            }

            zip = zip.Trim();
            if (!Regex.IsMatch(zip, @"^2\d{5}$"))
            {
                ErrorMessage = "Код должен иметь вид 2XXXXX";
                return false;
            }

            return true;
        }
    }
}
