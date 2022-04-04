using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Categories;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORETest.Pages
{
    public class CategoryModel : PageModel
    {
		private IPostservices _postservices;
		public CategoryModel(IPostservices postservices)
		{
			_postservices = postservices;
		}
		public IEnumerable<Post> Catposts;

		public IActionResult OnGet(String category)
		{
			if (category == null)
				return NotFound();
			Catposts = _postservices.GetPostsbyCategory(category);
			return Page();
		}
		public IActionResult OnPost(String category)
		{
			return Page();
		}
	}
}
