using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.Posts
{
	public class PostFilterDto
    {
        public int PageCount { get; set; }
        public IEnumerable<PostDTO> Posts { get; set; }
        public PostFilterParams FilterParams { get; set; }
    }
    public class PostFilterParams
    {
        public string Title { get; set; }
        public string CategorySlug { get; set; }
        public int PageId { get; set; }
        public int Take { get; set; }
    }
}
