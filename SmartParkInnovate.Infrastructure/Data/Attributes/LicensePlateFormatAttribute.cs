using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartParkInnovate.Infrastructure.Data.Attributes
{
    public class LicensePlateFormatAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            string licensePlate = value.ToString();

            string[] patternTypes = new string[]
            {
                @"^([A-Z]{2}[0-9]{4}[A-Z]{2})$",
                @"^([A-Z]{1}[0-9]{4}[A-Z]{2})$",
                @"^([A-Z]{2}[0-9]{6})$",
                @"^([A-Z]{1}[0-9]{5}[A-Z]{2})$",
                @"^([A-Z]{1}[0-9]{7})$"
            };


            for (int i = 0; i < patternTypes.Length; i++)
            {
                if(Regex.Match(licensePlate, patternTypes[i]).Success)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
