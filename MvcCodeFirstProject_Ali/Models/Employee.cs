using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MvcCodeFirstProject_Ali.Models
{
    public partial class Employee
    {
        public int EmployeeID { get; set; }

        [Display(Name = "Tourist Name")]
        [Required(ErrorMessage = "Please input your name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Position Name")]
        [Required(ErrorMessage = "Please input your position name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Position { get; set; }

        [Display(Name = "Name of Office")]
        [Required(ErrorMessage = "Please input your office name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Office { get; set; }

        [Display(Name = "Payment Amount")]
        [Required(ErrorMessage = "Please input your salary amount here!!!")]
        [Range(99,35000, ErrorMessage = "Amount must be 99 to 35000 tk.")]
        public int Salary { get; set; }

        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Employee()
        {
            ImagePath = "~/AppFiles/Images/default.png";
        }


    }
}

