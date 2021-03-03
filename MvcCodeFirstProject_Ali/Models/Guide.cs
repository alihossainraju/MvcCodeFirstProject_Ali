using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCodeFirstProject_Ali.Models
{   public partial class Guide
    {
        public int GuideID { get; set; }
        [Display(Name = "Guide Name")]
        [Required(ErrorMessage = "Please input your name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Guide Age")]
        [Required(ErrorMessage = "Please input your age here!!!")]
        [Range(18, 60, ErrorMessage = "Age must be 18 to 30 year")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please input your E-mail address here!!!")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Please input your phone number here!!!")]
        public Nullable<int> Phone { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Permanent Address")]
        [Required(ErrorMessage = "Please input your address here!!!")]
        public string Address { get; set; }

        [Display(Name = "Visiting Date")]
        [Required(ErrorMessage = "Please input your visiting date here!!!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> VisitDate { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please input your password here")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(\S)+", ErrorMessage = "Whitespace not Allowed in Password")]
        public string Password { get; set; }
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Input same password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please input same password here!!")]
        public string ConfirmPassword { get; set; }
    }

}
