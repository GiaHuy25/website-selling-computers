using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebprojectCK.Custom
{
    public class PriceDivisibleBy1000: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (int)value % 1000 == 0;
        }
    }
}