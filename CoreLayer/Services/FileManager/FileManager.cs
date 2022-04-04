using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CoreLayer.Services.FileManager
{
	public class FileManager : IFileManager
	{

		public string SaveFile(IFormFile File, string SavePath)
		{
			var FileName = Guid.NewGuid() + Path.GetExtension(File.FileName);
			var folderpath = Path.Combine(Directory.GetCurrentDirectory(), SavePath.Replace("/", "\\"));
			if (!Directory.Exists(folderpath))
			{
				Directory.CreateDirectory(folderpath);
			}
			var fullpath = Path.Combine(folderpath, FileName);

			using var stream = new FileStream(fullpath, FileMode.Create);
			File.CopyTo(stream);
			return FileName;
		}
	}
}
