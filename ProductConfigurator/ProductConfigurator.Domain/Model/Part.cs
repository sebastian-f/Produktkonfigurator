﻿using System;
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
		public decimal Price { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Code { get; set; }

        public IList<Order> Orders { get; set; }

        

		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Category Category { get; set; }
	}
}
