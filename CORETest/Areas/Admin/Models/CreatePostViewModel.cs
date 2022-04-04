
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORETest.Areas.Admin.Models
{
	public class CreatePostViewModel
	{
		public int UserId { get; set; }
		[Display(Name ="گـروه")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public int CategoryId { get; set; }
		[Display(Name = "دسته بندی")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public int SubCategoryId { get; set; }
		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(300)]
		public string Title { get; set; }
		[Display(Name = "Slug")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MaxLength(400)]
		public string Slug { get; set; }
		[Display(Name ="توضیحات")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		[Display(Name ="تصویر اول")]
		public IFormFile Photo1 { get; set; }
		[Display(Name = "تصویر دوم")]
		public IFormFile Photo2 { get; set; }
	}
}
