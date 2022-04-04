using CoreLayer.DTOs.Categories;
using CoreLayer.Utilities;
using CORETest.Utilities;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Categories
{
	public class Categoryservices : ICategoryservices
	{
		private readonly BlogContext db;
		public Categoryservices(BlogContext blogContext)
		{
			db = blogContext;
		}
		public OperationResault CreateCategory(CreateCategoryDTO createCategory)
		{
			bool ExistSlug = db.categories.Any(c => c.Slug == createCategory.Slug);
			if (ExistSlug)
			{
				return OperationResault.Error("Slug موجود میباشد");
			}
			var create = new Category()
			{
				MetaDescription = createCategory.MetaDescription,
				MetaTag = createCategory.MetaTag,
				ParentID = createCategory.ParentID,
				Slug = createCategory.Slug,
				Title = createCategory.Title
			};
			db.categories.Add(create);
			db.SaveChanges();
			return OperationResault.Success();
		}

		public OperationResault DeleteCategory(CategoryDTO categoryDTO)
		{
			try
			{
				var category = db.categories.FirstOrDefault(c => c.Id == categoryDTO.Id);
				db.categories.Remove(category);
				db.SaveChanges();
				return OperationResault.Success();
			}
			catch
			{
				return OperationResault.Error();
			}
		}

		public OperationResault EditCategory(EditCategoryDTO editCategory)
		{
			bool ExistSlug = db.categories.Any(c=>c.Slug==editCategory.Slug);
			if (ExistSlug)
			{
				return OperationResault.Error("Slug موجود میباشد");
			}
			var category = db.categories.FirstOrDefault(c => c.Id == editCategory.Id);

			category.MetaDescription = editCategory.MetaDescription;
			category.MetaTag = editCategory.MetaTag;
			category.Slug = editCategory.Slug.ToSlug();
			category.Title = editCategory.Title;
			db.categories.Update(category);
			db.SaveChanges();
			return OperationResault.Success();
		}

		public IEnumerable<CategoryDTO> GetAllCategories()
		{
			return db.categories.Select(c => new CategoryDTO()
			{
				MetaDescription = c.MetaDescription,
				MetaTag = c.MetaTag,
				ParentID = c.ParentID,
				Slug = c.Slug,
				Title = c.Title,
				Id = c.Id
			}).ToList();
		}

		public CategoryDTO GetCaegoryBy(int id)
		{
			var c = db.categories.FirstOrDefault(c=>c.Id==id);
			if (c==null)
			{
				return null;
			}
			var category = new CategoryDTO() 
			{
				MetaDescription = c.MetaDescription,
				MetaTag = c.MetaTag,
				ParentID = c.ParentID,
				Slug = c.Slug,
				Title = c.Title,
				Id = c.Id
			};
			return category;
		}

		public CategoryDTO GetCaegoryBy(string slug)
		{
			var c = db.categories.FirstOrDefault(c => c.Slug == slug);
			if (c == null)
			{
				return null;
			}
			var category = new CategoryDTO()
			{
				MetaDescription = c.MetaDescription,
				MetaTag = c.MetaTag,
				ParentID = c.ParentID,
				Slug = c.Slug,
				Title = c.Title,
				Id = c.Id
			};
			return category;
		}
		public List<CategoryDTO> GetChildCategory(int ParentID)
		{
			return db.categories.Where(c => c.ParentID == ParentID).Select(category=>new CategoryDTO
			{ 
			Id=category.Id,
			MetaDescription=category.MetaDescription,
			MetaTag=category.MetaTag,
			ParentID=category.ParentID,
			Slug=category.Slug,
			Title=category.Title
			}).ToList();
		}
	}
}
