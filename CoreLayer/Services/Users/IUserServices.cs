using CoreLayer.DTOs.Users;
using CORETest.Utilities;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Users
{
	public interface IUserServices
	{
		OperationResault RegisterUser(UserRegisterDTO userRegister);
		UserDTO LoginUser(UserLoginDTO userLogin);
	}
}
