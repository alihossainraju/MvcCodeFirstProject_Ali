using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Ali.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        [Required(ErrorMessage ="Please input your food name")]
        public string FoodName { get; set; }
        [Required(ErrorMessage = "Please input a short description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please input your purchase date")]
        [Display(Name ="Purchase Date ")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        [Required(ErrorMessage = "Please input purchase date")]
        [Display(Name = "Image ")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}