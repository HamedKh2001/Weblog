using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORETest.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	public class HomeController : Controller
	{		
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult signout()
		{
			HttpContext.SignOutAsync();
			return Redirect("/");
		}
	}
}
