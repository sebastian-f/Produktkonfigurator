using ProductConfigurator.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI.Models
{
    public class CategoryPartsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int ProductId { get; set; }
        public IList<PartViewModel> Parts { get; set; }
    }

    //public class SimplePartViewModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Price { get; set; }
    //}
}