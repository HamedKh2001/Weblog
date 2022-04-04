using CoreLayer.DTOs.Posts;
using CoreLayer.Services.Categories;
using CoreLayer.Utilities;
using CORETest.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORETest.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class PostsController : Controller
	{
		private readonly IPostservices _postservices;
		public PostsController(IPostservices postservices)
		{
			_postservices = postservices;
		}
		public IActionResult Index(int pageid = 1, string title = "", string categorySlug = "")
		{
			return View(_postservices.GetPostsByFilter(new PostFilterParams()
			{
				CategorySlug = categorySlug,
				PageId = pageid,
				Title = title,
				Take = 2
			}));
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CreatePostViewModel createPostViewModel)
		{
			if (ModelState.IsValid)
			{
				var postDTO = new CreatePostDTO()
				{
					Photo1 = createPostViewModel.Photo1,
					Slug = createPostViewModel.Slug,
					Title = createPostViewModel.Title,
					CategoryId = createPostViewModel.CategoryId,
					Description = createPostViewModel.Description,
					IsDelete = false,
					UserId = User.GetUserID(),
					SubCategoryId = createPostViewModel.SubCategoryId
				};
				var res = _postservices.CreatePost(postDTO);
			}
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var post = _postservices.GetPostByid(id);
			var model = new EditPostViewModel()
			{
				id = id,
				CategoryId = post.CategoryId,
				Description = post.Description,
				Slug = post.Slug,
				SubCategoryId = post.SubCategoryId,
				Title = post.Title
			};
			ViewData["PIC1"] = post.Photo1;
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(EditPostViewModel EditVM)
		{
			var post = new EditPostDTO()
			{
				Id = EditVM.id,
				CategoryId = EditVM.CategoryId,
				Description = EditVM.Description,
				SubCategoryId = EditVM.SubCategoryId,
				Photo1 = EditVM.Photo1,
				//Photo2 = EditVM.Photo2,
				Slug = EditVM.Slug,
				Title = EditVM.Title
			};
			var res = _postservices.EditPost(post);
			if (res.Status == Utilities.OperationResultStatus.Success)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Delete(int id)
		{
			var model = _postservices.GetPostByid(id);
			var modelVM = new PostViewModel()
			{
				CategoryId = model.CategoryId,
				CreationDate = model.CreationDate,
				Description = model.Description,
				Id = model.Id,
				IsDelete = model.IsDelete,
				Photo1 = model.Photo1,
				Photo2 = model.Photo2,
				Slug = model.Slug,
				SubCategoryId = model.SubCategoryId,
				Title = model.Title,
				Visit = model.Visit
			};
			return PartialView(modelVM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(PostViewModel PostVM)
		{
			var res = _postservices.DeletePost(PostVM.Id);
			if (res.Status == Utilities.OperationResultStatus.Success)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View(PostVM);
			}
		}
		[Route("/Upload/Article")]
		public IActionResult Ckeditorimage(IFormFile Upload)
		{
			string filename;
			if (Upload != null)
			{
				filename = _postservices.SaveImg(Upload);
				return Json(new { Uploaded = true, Url = $"/images/{filename}" });
			}
			return null;
		}
		public IActionResult PostCount()
		{
			return new JsonResult(_postservices.GetCountOfPosts());
		}
	}
}
