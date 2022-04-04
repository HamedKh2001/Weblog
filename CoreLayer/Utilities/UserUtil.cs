using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities
{
	public static class UserUtil
	{
		public static int GetUserID(this ClaimsPrincipal claimsPrincipal)
		{
			return Convert.ToInt32(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
		}
	}
}
