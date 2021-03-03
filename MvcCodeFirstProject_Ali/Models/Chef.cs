using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFirstProject_Ali.Models
{

    public partial class Chef
    {
        public int ChefID { get; set; }


        public string ChefName { get; set; }


        public string EmailAddress { get; set; }


        public string CellPhone { get; set; }


        public string ContactAddress { get; set; }
    }
}
