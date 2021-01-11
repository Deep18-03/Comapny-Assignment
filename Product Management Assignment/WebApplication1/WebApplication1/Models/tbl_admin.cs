//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tbl_admin
    {
        [Key]
        public int ad_id { get; set; }
        [Required(ErrorMessage ="UserName is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(length: 10, ErrorMessage = "Length should not be more than 10 characters")]
        [MinLength(length: 2, ErrorMessage = "Minimum charcters should be 2")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]
        [MaxLength(length: 10, ErrorMessage = "Length should not be more than 10 characters")]
        [MinLength(length: 2, ErrorMessage = "Minimum charcters should be 2")]
        public string LastName { get; set; }
    }
}