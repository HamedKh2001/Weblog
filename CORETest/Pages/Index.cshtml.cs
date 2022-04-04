using CoreLayer.Services.Categories;
using CoreLayer.Services.Users;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORETest.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private IPostservices _postservices;
		private ICategoryservices _categoryservices;
		public IndexModel(ILogger<IndexModel> logger, IPostservices postservices, ICategoryservices categoryservices)
		{
			_logger = logger;
			_postservices = postservices;
			_categoryservices = categoryservices;
		}
		public IEnumerable<Post> LatestPosts;
		public IEnumerable<Post> BreakingPosts;
		public List<Post> first4Posts;
		public IEnumerable<Post> ElitePosts;
		public IEnumerable<Post> AllPosts;
		public IEnumerable<CoreLayer.DTOs.Categories.CategoryDTO> AllCategories;
		public IActionResult OnGet()
		{
			LatestPosts = _postservices.GetLatestPosts();
			BreakingPosts = _postservices.GetBreakingPosts();
			first4Posts = _postservices.Getfirst4Posts();
			ElitePosts = _postservices.GetElitePosts();
			AllCategories = _categoryservices.GetAllCategories();
			AllPosts = _postservices.GetAllPosts();
			return Page();
		}
		public IActionResult OnGetPopularPosts()
		{
			return Partial("_PopularPosts", _postservices.GetTopPosts());
		}
		public IActionResult OnGetCategories()
		{
			return Partial("_Categories", _categoryservices.GetAllCategories());
		}
		public IActionResult OnGetFooterCategories()
		{
			return Partial("_Categories", _categoryservices.GetAllCategories().Take(6).OrderByDescending(c=>c.Id));
		}
		public IActionResult OnGetHeaderCategories()
		{
			return Partial("_MainHeader", _categoryservices.GetAllCategories());
		}
		public IActionResult OnGetFooterPopularPosts()
		{
			return Partial("_FooterPopularPosts", _postservices.GetElitePosts().Take(2));
		}
	}
}
