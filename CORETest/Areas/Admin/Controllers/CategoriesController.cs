using CoreLayer.DTOs.Categories;
using CoreLayer.Services.Categories;
using CORETest.Areas.Admin.Models;
using CORETest.Utilities;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CORETest.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class CategoriesController : Controller
	{
		private readonly ICategoryservices _categoryservices;
		public CategoriesController(ICategoryservices categoryservice)
		{
			_categoryservices = categoryservice;
		}
		// GET: Categories
		public ActionResult Index()
		{
			IEnumerable<CategoryDTO> list = _categoryservices.GetAllCategories();
			return View(list);
		}

		// GET: Categories/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}
		[Route("Admin/Categories/Create/{parentid?}")]
		// GET: Categories/Create
		public ActionResult Create(int? parentid)
		{
			return View();
		}

		// POST: Categories/Create
		[HttpPost("Admin/Categories/Create/{parentid?}")]
		public ActionResult Create(int? parentid, CreateCategoryViewModel createCategoryViewModel)
		{
			var category = new CreateCategoryDTO()
			{
				Title = createCategoryViewModel.Title,
				MetaDescription = createCategoryViewModel.MetaDescription,
				MetaTag = createCategoryViewModel.MetaTag,
				ParentID = createCategoryViewModel.ParentID,
				Slug = createCategoryViewModel.Slug
			};

			var res = _categoryservices.CreateCategory(category);
			if (res.Status != OperationResultStatus.Success)
			{
				ModelState.AddModelError(nameof(createCategoryViewModel.Slug), res.Message);
				return View();
			}
			return RedirectToAction("Index");

		}

		public ActionResult Edit(int id)
		{
			//ViewData["title"] = Title;
			var category = _categoryservices.GetCaegoryBy(id);
			var showCategory = new EditCategoryViewModel()
			{
				MetaDescription = category.MetaDescription,
				MetaTag = category.MetaTag,
				Slug = category.Slug,
				Title = category.Title
			};
			return View(showCategory);
		}

		// POST: Categories/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, EditCategoryViewModel editModel)
		{
			var categoryDTO = new EditCategoryDTO()
			{
				Id = id,
				MetaDescription = editModel.MetaDescription,
				MetaTag = editModel.MetaTag,
				Slug = editModel.Slug,
				Title = editModel.Title
			};
			var res = _categoryservices.EditCategory(categoryDTO);
			if (res.Status != OperationResultStatus.Success)
			{
				ModelState.AddModelError(nameof(editModel.Slug), res.Message);
				return View();
			}
			return RedirectToAction("Index");
		}
		[Route("Admin/Categories/Delete/{id}")]
		// GET: Categories/Delete/5
		public ActionResult Delete(int id)
		{	
			var category = _categoryservices.GetCaegoryBy(id);
			var showCategory = new CategoryDTO()
			{
				MetaDescription = category.MetaDescription,
				MetaTag = category.MetaTag,
				Slug = category.Slug,
				Title = category.Title,
				
			};
			ViewData["Title"] = showCategory.Title;
			return PartialView(showCategory);
		}

		// POST: Categories/Delete/5
		[HttpPost("Admin/Categories/Delete/{id}")]
		[ValidateAntiForgeryToken]
		public ActionResult Delete( CategoryDTO categoryDTO)
		{
			var res = _categoryservices.DeleteCategory(categoryDTO);
			if (res.Status == OperationResultStatus.Success)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		
		public IActionResult GetChildCatefories (int parentID)
		{
			return new JsonResult(_categoryservices.GetChildCategory(parentID));
		}
		public IActionResult CategoryCount()
		{
			return new JsonResult(_categoryservices.GetAllCategories().Count());
		}
	}
}

