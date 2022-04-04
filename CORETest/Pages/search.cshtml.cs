using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORETest.Pages
{
	public class searchModel : PageModel
	{
		private readonly IPostservices _postservices;
		public searchModel(IPostservices postservices)
		{
			_postservices = postservices;
		}
		public PostFilterDto posts { get; set; }
		public void OnGet(int pageid = 1, string q = null, string categorySlug = null)
		{
			posts = _postservices.GetPostsByFilter(new PostFilterParams()
			{
				CategorySlug = categorySlug,
				PageId = pageid,
				Title = q,
				Take = 2
			});
		}
		public IActionResult OnGetRes(int pageid = 1, string q = null, string categorySlug = null)
		{
			var model = _postservices.GetPostsByFilter(new PostFilterParams()
			{
				CategorySlug = categorySlug,
				PageId = pageid,
				Title = q,
				Take = 2
			});
			return Partial("_searchview",model);
		}
	}
}
