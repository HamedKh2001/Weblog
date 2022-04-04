using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreLayer.DTOs.Users;
using CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORETest.Pages.Auth
{
	[BindProperties]
	[ValidateAntiForgeryToken]
	public class LoginModel : PageModel
	{

		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string UserName { get; set; }
		[Display(Name = "کلمه عبور")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Password { get; set; }

		private readonly IUserServices _userServices;
		public LoginModel(IUserServices userServices)
		{
			_userServices = userServices;
		}

		public void OnGet()
		{
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			var resault = _userServices.LoginUser(new UserLoginDTO
			{
				Password = Password,
				UserName = UserName
			});
			if (resault == null)
			{
				ModelState.AddModelError("UserName", "کاربری یافت نشد");
				return Page();
			}
			List<Claim> Claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name,resault.FullName),
				new Claim(ClaimTypes.NameIdentifier,resault.UserID.ToString())
			};
			var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var Claimprincipal = new ClaimsPrincipal(Identity);
			var prop = new AuthenticationProperties()
			{
				IsPersistent = true
			};
			HttpContext.SignInAsync(Claimprincipal, prop);
			
			return RedirectToPage("../Index");
		}
	}
}
