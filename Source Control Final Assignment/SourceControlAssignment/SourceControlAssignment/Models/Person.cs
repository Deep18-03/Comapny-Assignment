//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SourceControlAssignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(length: 10, ErrorMessage = "Length should not be more than 10 characters")]
        [MinLength(length: 2, ErrorMessage = "Minimum charcters should be 2")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [MaxLength(length: 10, ErrorMessage = "Length should not be more than 10 characters")]
        [MinLength(length: 2, ErrorMessage = "Minimum charcters should be 5")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Custom_Date]
        [AgeRangeValidation(ErrorMessage = "Age must be between 18 - 30", MinAge = 18, MaxAge = 30)]
        public string Birthdate { get; set; }
        [Required(ErrorMessage = "City Name is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "City Name is Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Addrress is required")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 100 char")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Contact number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(10, 50, ErrorMessage = "Enter number between 10 to 50")]
        public Nullable<int> Age { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm_Password { get; set; }
        public string image { get; set; }
    }
}
