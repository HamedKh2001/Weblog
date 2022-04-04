using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.PostComments
{
	public class CommentDTO
	{
		public string UserName { get; set; }
		public int PostId { get; set; }
		public string Text { get; set; }
		public DateTime Createtime { get; set; }
	}
}