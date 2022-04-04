using CoreLayer.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORETest.Areas.Admin.Models
{
	public class CreateCategoryViewModel
	{
		[Display(Name ="عنوان")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Title { get; set; }
		[Display(Name = "Slug")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Slug { get; set; }
		[Display(Name = "Metatag")]
		public string MetaTag { get; set; }
		[Display(Name = "MetaDescription")]
		public string MetaDescription { get; set; }
		public int? ParentID { get; set; }
	}
}
