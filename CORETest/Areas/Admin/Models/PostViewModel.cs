using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORETest.Areas.Admin.Models
{
	public class PostViewModel
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public bool IsDelete { get; set; }
		public int UserId { get; set; }
		public int CategoryId { get; set; }
		public int SubCategoryId { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public int Visit { get; set; }
		public string Photo1 { get; set; }
		public string Photo2 { get; set; }
	}
}
