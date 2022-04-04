using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.DTOs.PostComments;
using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Categories;
using CoreLayer.Services.PostComments;
using CoreLayer.Services.Users;
using CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORETest.Pages
{
	public class PostModel : PageModel
	{
		private IPostCommentservices PCS;
		private IPostservices _postservices;
		public PostModel(IPostservices postservices, IPostCommentservices postCommentservices)
		{
			_postservices = postservices;
			PCS = postCommentservices;
		}

		public PostDTO post { get; set; }
		[BindProperty]
		public int PostId { get; set; }
		[BindProperty]
		public string Text { get; set; }

		public IEnumerable<PostDTO> Releatedposts;
		public IEnumerable<CommentDTO> comments;

		public IActionResult OnGet(string slug)
		{
			if (slug == null)
				return NotFound();

			post = _postservices.GetPostBySlug(slug);
			comments = PCS.GetComments(post.Id);
			Releatedposts = _postservices.GetRelatedPosts(post.SubCategoryId, post.CategoryId);
			return Page();
		}

		public IActionResult OnPost(string slug)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToPage("Post", new { slug });
			}
			PCS.AddComment(new AddcommentDTO()
			{
				PostId = PostId,
				Text = Text,
				UserId = User.GetUserID()
			});
			
			return RedirectToPage("Post", new { slug });
		}
	}
}