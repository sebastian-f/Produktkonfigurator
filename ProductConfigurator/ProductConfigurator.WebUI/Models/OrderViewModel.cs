﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI.Models
{
    public class OrderViewModel
    {
        public string ProductName { get; set; }
        IList<OrderCategoryPartViewModel> CategoryParts { get; set; }
        public DateTime DeliveryDate { get; set; }
    }

    public class OrderCategoryPartViewModel
    {
        public string CategoryName { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
        public string PartCode { get; set; }
    }
}