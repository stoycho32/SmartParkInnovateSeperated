using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartParkInnovate.Infrastructure.Data.Attributes
{
    public class PostFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string objectValueToString = value.ToString();
            string patternType = @"\w";


            if (!Regex.Match(objectValueToString, patternType).Success)
            {
                return false;
            }

            return true;
        }
    }
}
