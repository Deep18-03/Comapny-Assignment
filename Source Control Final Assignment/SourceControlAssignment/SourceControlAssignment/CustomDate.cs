using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlAssignment
{
    public class Custom_Date : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {

            DateTime CurrentDate = DateTime.Now;

            string Message = string.Empty;


            if (Convert.ToDateTime(value) > CurrentDate)

            {

                Message = "Date of Birth cannot be Greater than current date";

                return new ValidationResult(Message);

            }

            return ValidationResult.Success;




        }
    }
}