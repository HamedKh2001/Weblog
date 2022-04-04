
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CORETest.Areas.Admin.Models
{
	public class EditPostViewModel
	{
		public int id { get; set; }
		[Display(Name = "گـروه")]
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
		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		[Display(Name = "تصویر اول")]
		public IFormFile Photo1 { get; set; }
		[Display(Name = "تصویر دوم")]
		public IFormFile Photo2 { get; set; }
	}
}
