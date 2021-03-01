﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileOperations
{
    public class FileOperation
    {
        public static string CreateImageFile(IFormFile file)
        {
            var result = FilePath(file);
            var directoryPath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(directoryPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Move(directoryPath, result.newPath);
            return result.Path2;
        }
        public static string UpdateImageFile(string oldPath, IFormFile file)
        {
            var result = FilePath(file);
            var directoryPath = result.newPath;
            var imagePath = result.Path2;
            if (oldPath.Length > 0)
            {
                using (var stream = new FileStream(directoryPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(oldPath);

            return imagePath;
        }

        public static string DeleteImageFile(string imagePath)
        {
            File.Delete(imagePath);
            return imagePath;
        }
        private static (string newPath, string Path2) FilePath(IFormFile file)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.FileName);
            var fileExtension = fileInfo.Extension;
            var fileName = Guid.NewGuid().ToString("N") + fileExtension;
            string result = $@"{Environment.CurrentDirectory + @"\wwwroot\Images"}\{fileName}";

            return (result, $"\\Images\\{fileName}");
        }
    }
}
