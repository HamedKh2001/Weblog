using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORETest.Areas.Admin.Models
{
	public class EditCategoryViewModel
	{
		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Title { get; set; }
		[Display(Name = "Slug")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Slug { get; set; }
		[Display(Name = "MetaTag")]
		[Required(ErrorMessage = "{0} را وارد کنید")]

		public string MetaTag { get; set; }
		[Display(Name = "MetaDescription")]
		[Required(ErrorMessage = "{0} را وارد کنید")]

		public string MetaDescription { get; set; }
	}
}
