
using CoreLayer.DTOs.PostComments;
using CORETest.Utilities;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.PostComments
{
	public class PostCommentservices : IPostCommentservices
	{
		private BlogContext db;
		public PostCommentservices(BlogContext blogContext)
		{
			db = blogContext;
		}
		public OperationResault AddComment(AddcommentDTO addcomment)
		{
			try
			{
				var pc = new PostComment()
				{
					UserId = addcomment.UserId,
					Text = addcomment.Text,
					PostId = addcomment.PostId,
				};
				db.PostComments.Add(pc);
				db.SaveChanges();
				return OperationResault.Success();
			}
			catch
			{
				return OperationResault.Error();
			}
		}

		public IEnumerable<CommentDTO> GetComments(int id)
		{
			try
			{
				return db.PostComments.Where(c => c.PostId == id).Include(u => u.User).Select(c => new CommentDTO()
				{
					PostId = c.PostId,
					Text = c.Text,
					UserName = c.User.UserName,
					Createtime=c.CreationDate
				});
			}
			catch 
			{
				return null;
			}
		}
	}
}
