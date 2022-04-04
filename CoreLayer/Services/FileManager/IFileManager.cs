using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.FileManager
{
	public interface IFileManager
	{
		string SaveFile(IFormFile formFile, string SavePath);
	}
}
