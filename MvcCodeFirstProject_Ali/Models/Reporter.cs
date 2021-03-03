using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFirstProject_Ali.Models
{
    public partial class Reporter
    {
        public int Id { get; set; }
        [Display(Name = "Reporter's Name")]
        [Required(ErrorMessage = "Please input reporter name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Reporter's Age")]
        [Required(ErrorMessage = "Please input reporter age here!!!")]
        [Range(18, 60, ErrorMessage = "Age must be 18 to 30 year")]
        public int Age { get; set; }

        [Display(Name = "District Name")]
        [Required(ErrorMessage = "Please input district name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "must be 3-30 char")]
        public string State { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please input country name here!!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "must be 3-30 char")]
        public string Country { get; set; }
    }
}
