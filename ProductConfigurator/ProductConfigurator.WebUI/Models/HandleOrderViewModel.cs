using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI.Models
{
    public class HandleOrderViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public IList<PartViewModel> Parts { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public bool Sent { get; set; }
    }
}