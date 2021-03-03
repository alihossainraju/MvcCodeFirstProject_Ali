using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Ali.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
    
        public string ProductName {get;set;}

        public int Quantity { get; set; }

        public decimal Price { get; set; }


        public decimal Amount { get; set; }

        public Guid TravellerID { get; set; }

        public virtual Traveller Traveller { get; set; }
        
    }
}