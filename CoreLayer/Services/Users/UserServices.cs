using CoreLayer.DTOs.Users;
using CORETest.Utilities;
using DataLayer.Context;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Users
{
	public class UserServices : IUserServices
	{
		private readonly BlogContext db;
		public UserServices(BlogContext blogContext)
		{
			db = blogContext;
		}

		public UserDTO LoginUser(UserLoginDTO userLogin)
		{
			var password = userLogin.Password.EncodeToMd5();
			var username = userLogin.UserName;
			var UserInDb = db.Users.FirstOrDefault(u => u.UserName == username);
			if (UserInDb.Password == password && UserInDb.UserName == username)
			{
				var userdto = new UserDTO()
				{
					FullName = UserInDb.FullName,
					Password = UserInDb.Password,
					Role = UserInDb.Role,
					UserID = UserInDb.Id,
					UserName = UserInDb.UserName
				};
				return userdto;
			}
			else
			{
				return null;
			}
		}
		public OperationResault RegisterUser(UserRegisterDTO userRegister)
		{
			bool IsExistUser = db.Users.Any(u => u.UserName == userRegister.UserName);
			if (IsExistUser)
			{
				return OperationResault.Error("نام کاربری تکراری است");
			}

			var HashPassword = userRegister.Password.EncodeToMd5();
			db.Users.Add(new User()
			{
				UserName = userRegister.UserName,
				Password = HashPassword,
				IsDelete = false,
				Role = UserRole.User,
				FullName = userRegister.FullName,
				CreationDate = DateTime.Now
			});
			db.SaveChanges();
			return OperationResault.Success();
		}
	}
}
