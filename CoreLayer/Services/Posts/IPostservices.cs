using CoreLayer.DTOs.Posts;
using CORETest.Utilities;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Categories
{
	public interface IPostservices
	{
		OperationResault CreatePost(CreatePostDTO createPostDTO);
		string SaveImg(IFormFile file);
		OperationResault EditPost(EditPostDTO editPostDTO);
		OperationResault DeletePost(int id);
		PostFilterDto GetPostsByFilter(PostFilterParams postFilterParams);
		PostDTO GetPostByid(int id);
		bool IsSlugExist(string slug);
		PostDTO GetPostBySlug(string slug);
		IEnumerable<Post> GetTopPosts();
		IEnumerable<Post> GetLatestPosts();
		IEnumerable<PostDTO> GetRelatedPosts(int subid, int catid);
		IEnumerable<Post> GetBreakingPosts();
		List<Post> Getfirst4Posts();
		IEnumerable<Post> GetElitePosts();
		int GetCountOfPosts();
		IEnumerable<Post> GetAllPosts();
		IEnumerable<Post> GetPostsbyCategory(string catname);
	}
}
