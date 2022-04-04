using Microsoft.AspNetCore.Http;

namespace CoreLayer.DTOs.Posts
{
	public class EditPostDTO
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public int? SubCategoryId { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public IFormFile Photo1 { get; set; }
		public IFormFile Photo2 { get; set; }
	}
}
