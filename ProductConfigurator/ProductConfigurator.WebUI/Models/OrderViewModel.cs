using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI.Models
{

    public class OrderViewModel
    {
        [Display(Name="Product")]
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public IList<OrderCategoryPartViewModel> CategoryParts { get; set; }
        [Display(Name = "Ready for delivery")]
        public DateTime DeliveryDate { get; set; }
        [Display(Name = "Total price")]
        public decimal TotalPrice { get; set; }
        
    }

    public class OrderCategoryPartViewModel
    {
        public string CategoryName { get; set; }
        public int PartId { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
        public string PartCode { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}