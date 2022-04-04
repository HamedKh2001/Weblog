using CoreLayer.DTOs.PostComments;
using CORETest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.PostComments
{
	public interface IPostCommentservices
	{
		OperationResault AddComment(AddcommentDTO addcomment);
		IEnumerable<CommentDTO> GetComments(int id);
	}
}
