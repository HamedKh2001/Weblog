using CoreLayer.DTOs.Categories;
using CORETest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Categories
{
	public interface ICategoryservices
	{
		OperationResault CreateCategory(CreateCategoryDTO createCategory);
		OperationResault EditCategory(EditCategoryDTO editCategory);
		IEnumerable<CategoryDTO> GetAllCategories();
		CategoryDTO GetCaegoryBy(int id);
		CategoryDTO GetCaegoryBy(string slug);
		OperationResault DeleteCategory(CategoryDTO categoryDTO);
		List<CategoryDTO> GetChildCategory(int ParentID);
	}
}
