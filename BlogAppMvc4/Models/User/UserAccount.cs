using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogAppMvc4.Models.User
{
    public class Register
    {
        [Key]
        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$", ErrorMessage = "First Name is not Proper")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$", ErrorMessage = "Last Name is not Proper")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Age")]
        [RegularExpression(@"^[0-9_-]{2}$", ErrorMessage = "Age is not Proper")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Pass word is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
    }
    public class LogIn
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}