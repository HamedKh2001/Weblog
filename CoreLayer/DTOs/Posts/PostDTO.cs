using System;

namespace CoreLayer.DTOs.Posts
{
	public class PostDTO
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public bool IsDelete { get; set; }
		public string Author { get; set; }
		public int CategoryId { get; set; }
		public int SubCategoryId { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public int Visit { get; set; }
		public string Photo1 { get; set; }
		public string Photo2 { get; set; }
		public string CategoryName { get; set; }
		public string SubCategoryName { get; set; }
	}
}
