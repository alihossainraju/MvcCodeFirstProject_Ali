using MvcCodeFirstProject_Ali.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Ali.ViewModels
{
    public class FoodVM
    {
        public int FoodID { get; set; }
        [Required(ErrorMessage ="Please input food name")]
        public string FoodName { get; set; }
        [Required(ErrorMessage = "Please comment something about food")]

        public string Description { get; set; }
        [Required]
        [CustomHireDate(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public string ImagePath { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }

    }
}