﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductConfigurator.Domain.Model
{
	public class Order
	{
		public int Id { get; set; }
		public double Price { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Code { get; set; }

		[ForeignKey("User")]
		public virtual int UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }
	}
}
