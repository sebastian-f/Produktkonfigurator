using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI.Models
{
	public class UserViewModel
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Telephone { get; set; }
		public string Email { get; set; }
		public string Company { get; set; }
		public string StreetName { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}