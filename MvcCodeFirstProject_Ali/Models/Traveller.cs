﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject_Ali.Models
{
    public class Traveller
    {
        public Guid TravellerID { get;set;}

        public string Name { get; set; }

        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}