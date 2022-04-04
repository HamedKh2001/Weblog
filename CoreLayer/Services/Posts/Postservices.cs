using CoreLayer.DTOs.Posts;
using CoreLayer.Services.FileManager;
using CoreLayer.Utilities.Mapers;
using CORETest.Utilities;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreLayer.Services.Categories
{
	public class Postservices : IPostservices
	{
		IFileManager _fileManager;
		private readonly BlogContext db;
		public Postservices(IFileManager fileManager, BlogContext blogContext)
		{
			db = blogContext;
			_fileManager = fileManager;
		}
		public string SaveImg(IFormFile file)
		{
			string imagename = null;
			if (file != null)
			{
				imagename = _fileManager.SaveFile(file, "wwwroot/images");
			}
			return imagename;
		}
		public OperationResault CreatePost(CreatePostDTO createPostDTO)
		{
			try
			{
				string imagename = null;
				if (createPostDTO.Photo1 != null)
				{
					imagename = _fileManager.SaveFile(createPostDTO.Photo1, "wwwroot/images/posts");
				}
				var post = PostMappers.MapToCreatePost(createPostDTO, imagename);
				db.Add(post);
				db.SaveChanges();
				return OperationResault.Success();
			}
			catch
			{
				return OperationResault.Error();
			}
		}

		public OperationResault DeletePost(int id)
		{
			var target = db.Posts.FirstOrDefault(i => i.Id == id);
			try
			{
				db.Posts.Remove(target);
				db.SaveChanges();
				return OperationResault.Success();
			}
			catch
			{
				return OperationResault.Error();
			}
		}

		public OperationResault EditPost(EditPostDTO editPostDTO)
		{

			try
			{
				string imagename = null;
				if (editPostDTO.Photo1 != null)
				{
					imagename = _fileManager.SaveFile(editPostDTO.Photo1, "wwwroot/images/posts");
				}

				Post target = db.Posts.FirstOrDefault(i => i.Id == editPostDTO.Id);

				if (editPostDTO.SubCategoryId == 0)
				{
					target.SubCategoryId = null;
				}
				else
				{
					target.SubCategoryId = editPostDTO.SubCategoryId;
				}
				target.Description = editPostDTO.Description;
				target.Photo1 = imagename;
				//target.Photo2 = editPostDTO.Photo2;
				target.Slug = editPostDTO.Slug;
				target.Title = editPostDTO.Title;

				target.CategoryId = editPostDTO.CategoryId;
				db.Posts.Update(target);
				db.SaveChanges();
				return OperationResault.Success();
			}
			catch
			{
				return OperationResault.Error();
			}
		}

		public PostDTO GetPostByid(int id)
		{
			try
			{
				var target = db.Posts
					.Include(c => c.SubCategory)
					.Include(c => c.Category)
					.Include(c => c.User)
					.FirstOrDefault(i => i.Id == id);
				return PostMappers.MapToPostDTO(target);
			}
			catch
			{
				return null;
			}
		}
		public PostDTO GetPostBySlug(string slug)
		{
			try
			{
				var target = db.Posts
					.Include(c => c.SubCategory)
					.Include(c => c.Category)
					.Include(c => c.User)
					.FirstOrDefault(i => i.Slug == slug);
				target.Visit++;
				db.SaveChanges();
				return PostMappers.MapToPostDTO(target);
			}
			catch
			{
				return null;
			}
		}

		public PostFilterDto GetPostsByFilter(PostFilterParams FilterParams)
		{
			var filteredposts = db.Posts
				.Include(c => c.Category)
				.Include(c => c.SubCategory)
				.Include(c => c.User)
				.OrderByDescending(c => c.CreationDate).AsQueryable();

			if (!string.IsNullOrWhiteSpace(FilterParams.CategorySlug))
			{
				filteredposts = filteredposts.Where(c => c.Category.Slug.Contains(FilterParams.CategorySlug) ||
				c.SubCategory.Slug.Contains(FilterParams.CategorySlug));
			}
			if (!string.IsNullOrWhiteSpace(FilterParams.Title))
			{
				filteredposts = filteredposts.Where(c => c.Title.Contains(FilterParams.Title));
			}
			var skip = (FilterParams.PageId - 1) * FilterParams.Take;
			var pageCount = filteredposts.Count() / FilterParams.Take;

			return (new PostFilterDto()
			{
				Posts = filteredposts.Skip(skip).Take(FilterParams.Take).Select(c => PostMappers.MapToPostDTO(c)).ToList(),
				PageCount = pageCount,
				FilterParams = FilterParams
			});
		}

		public bool IsSlugExist(string slug)
		{
			return db.categories.Any(s => s.Slug == slug);
		}

		public IEnumerable<Post> GetTopPosts()
		{
			var y = db.Posts
				.Include(p => p.SubCategory)
				.Include(p => p.Category)
				.Include(p => p.User)
				.OrderByDescending(p => p.Visit)
				.Take(5);
			return y;
		}

		public IEnumerable<PostDTO> GetRelatedPosts(int subid, int catid)
		{
			return db.Posts
				.Where(p => p.SubCategoryId == subid || p.CategoryId == catid)
				.Take(6)
				.Select(p => PostMappers.MapToPostDTO(p)).ToList();
		}

		public int GetCountOfPosts()
		{
			return db.Posts.Count();
		}

		public IEnumerable<Post> GetLatestPosts()
		{
			return db.Posts
				.OrderByDescending(p => p.CreationDate)
				.Take(6)
				.Include(p => p.User)
				.Include(p => p.Category)
				.Include(p => p.SubCategory);
		}

		public IEnumerable<Post> GetBreakingPosts()
		{
			return db.Posts.Where(p => p.Slug.Contains("داغ"));
		}

		public List<Post> Getfirst4Posts()
		{
			return db.Posts.Where(p => p.Slug.Contains("داغ")).Take(4).Include(c => c.Category).Include(c => c.User).ToList();
		}

		public IEnumerable<Post> GetElitePosts()
		{
			return db.Posts.Where(p => p.Slug.Contains("منتخب")).Include(c => c.User);
		}

		public IEnumerable<Post> GetPostsbyCategory(string catname)
		{
			try
			{
				return db.Posts
					.Include(c => c.SubCategory)
					.Include(c => c.Category)
					.Include(c => c.User)
					.Where(c => c.Category.Title == catname || c.SubCategory.Title == catname);
			}
			catch
			{
				return null;
			}
		}

		public IEnumerable<Post> GetAllPosts()
		{
			return db.Posts;
		}
	}
}