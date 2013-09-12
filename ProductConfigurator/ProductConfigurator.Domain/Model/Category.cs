using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Domain.Model
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Part> Parts { get; set; }
	}
}