using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProductConfigurator.Domain.Model
{
	public class Part
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public TimeSpan Delivery { get; set; }
		public string Code { get; set; }
		public Category Category { get; set; }

		[ForeignKey("Product")]
		public virtual int ProductId { get; set; }

		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }
	}
}
