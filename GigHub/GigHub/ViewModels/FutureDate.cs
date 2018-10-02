using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime ;
          bool Valid =  DateTime.TryParseExact(Convert.ToString(value),
                "dd MM yyyy",
                CultureInfo.CurrentCulture,
                System.Globalization.DateTimeStyles.None,
                out dateTime);
            return (Valid && dateTime > DateTime.Now); 
        }
    }
}