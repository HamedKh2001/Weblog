using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs.PostComments
{
	public class AddcommentDTO
	{
		public int UserId { get; set; }
		public int PostId { get; set; }
		public string Text { get; set; }
	}
}
