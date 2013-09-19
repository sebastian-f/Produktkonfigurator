using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Domain.Model
{
	public class PartCompatibility
	{
		public int Id { get; set; }

		public Part PartOne { get; set; }

		public Part PartTwo { get; set; }
	}
}
