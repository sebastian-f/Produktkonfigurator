using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ProductConfigurator.WebUI
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{

			var role = Roles.Provider;
			

			if (!role.RoleExists("Admin"))
			{
				role.CreateRole("Admin");
			}
			if (Membership.GetUser("Admin", false) == null)
			{
				Membership.CreateUser("Admin", "Admin1!");
			}
			if (!role.GetRolesForUser("Admin").Contains("Admin"))
			{
				role.AddUsersToRoles(new[] { "Admin" }, new[] { "Admin" });
			} 
			

			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}