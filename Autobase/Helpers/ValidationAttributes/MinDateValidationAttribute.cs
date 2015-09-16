using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autobase.Helpers.ValidationAttributes
{
    //public class RangeDateAttribute : RangeAttribute
    //{
    //    private DateTime minDateValue = DateTime.Now;
    //    private DateTime maxDateValue = DateTime.MaxValue;
    //    TODO Edit Date validation (greater than today)
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value is DateTime)
    //        {
    //            DateTime valueDT = (DateTime)value;
    //            if (valueDT >= DateTime.Now)
    //            {
    //                return ValidationResult.Success;
    //            }
    //        }
    //        return new ValidationResult(this.ErrorMessage);
    //    }
    //}
}