using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI.Models
{
	public class PartViewModel
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Code { get; set; }
		public bool Checked { get; set; }

		public ICollection<PartViewModel> CompatibleParts { get; set; }

		public int CategoryId { get; set; }
	}
}