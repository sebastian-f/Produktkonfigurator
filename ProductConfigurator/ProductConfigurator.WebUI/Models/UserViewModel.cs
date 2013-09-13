using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductConfigurator.WebUI.Models
{
	public class UserViewModel
	{
		[HiddenInput(DisplayValue=false)]
		public int Id { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Telephone { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Company { get; set; }
		[Required]
		public string StreetName { get; set; }
		[Required]
		public string ZipCode { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string Country { get; set; }
	}
}