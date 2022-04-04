using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DTOs.Users;
using CoreLayer.Services.Users;
using CORETest.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORETest.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }
        [Display(Name = "مجدد کلمه عبور را وارد کنید")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare("Password",ErrorMessage ="رمز عبورها مطابقت ندارند")]
        public string RePassword { get; set; }

        private readonly IUserServices _userRegister;
		public RegisterModel(IUserServices userRegister)
		{
            _userRegister = userRegister;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
		{
            var Res = _userRegister.RegisterUser(new UserRegisterDTO { 
            FullName=FullName,
            Password=Password,
            UserName=UserName
            });
            if (Res.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", Res.Message);
                return Page();
            }
            return RedirectToPage("Login");
		}
    }
}