using CoreLayer.DTOs.Posts;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Mapers
{
	public static class PostMappers
	{
		public static Post MapToCreatePost(CreatePostDTO createPostDTO, string ph1)
		{
			int NewSubcategory;
			if (createPostDTO.SubCategoryId == null)
			{
				NewSubcategory = 0;
			}
			else
			{
				NewSubcategory = createPostDTO.SubCategoryId.Value;
			}
			return new Post()
			{
				Visit = 0,
				UserId = createPostDTO.UserId,
				Title = createPostDTO.Title,
				Slug = createPostDTO.Slug,
				Photo2 = null,
				Photo1 = ph1,
				CategoryId = createPostDTO.CategoryId,
				Description = createPostDTO.Description,
				SubCategoryId=createPostDTO.SubCategoryId
			};
		}
		public static PostDTO MapToPostDTO(Post post)
		{
			int NewSubcategory;
			if (post.SubCategoryId==null)
			{
				NewSubcategory = 0;
			}
			else
			{
				NewSubcategory = post.SubCategoryId.Value;
			}
			return new PostDTO()
			{
				CategoryName = post.Category.Title,
				SubCategoryName = post.SubCategory.Title,
				CategoryId = post.CategoryId,
				Description = post.Description,
				Photo1 = post.Photo1,
				Photo2 = post.Photo2,
				Slug = post.Slug,
				Title = post.Title,
				Author = post.User.FullName,
				Visit = post.Visit,
				Id = post.Id,
				CreationDate = post.CreationDate,
				IsDelete = post.IsDelete,
				SubCategoryId=NewSubcategory			
			};
		}

	}
}
