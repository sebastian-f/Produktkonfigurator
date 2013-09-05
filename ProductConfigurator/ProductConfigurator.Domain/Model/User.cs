using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Domain.Model
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public string Telephone { get; set; }
		public string Email { get; set; }
		public string Company { get; set; }
		public string StreetName { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string Country { get; set; }

		public List<Order> Oders { get; set; }
	
	
	}
}
