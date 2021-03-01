using CarRental.WebApi.Helpers.Abstract;
using CarRental.WebApi.Models;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApi.Helpers.Concrete
{
    public class FileHelper : IFileHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string uploads = "Uploads";
        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Check if the file is null or not.
        /// </summary>
        /// <param name="file">Takes an IFormFile type paramter.</param>
        /// <returns>Returns false if the file is null and returns true if the file is not null.</returns>
        public bool CheckIfFileNull(IFormFile file)
        {
            if (file.Length > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Checks file type by file's content type.
        /// </summary>
        /// <param name="file">Takes an IFormFile type paramter.</param>
        /// <returns>Returns the given file's type in string type. The type of file should be one of these image, text, audio, video or application types. If it cannot find the type of the given file, a string type error message is returned. </returns>
        public string CheckFileType(IFormFile file)
        {
            string fileType = file.ContentType;

            if (fileType.Contains("image"))
            {
                return "image";
            }
            else if (fileType.Contains("text"))
            {
                return "text";

            }
            else if (fileType.Contains("audio"))
            {
                return "audio";
            }
            else if (fileType.Contains("video"))
            {
                return "video";
            }
            else if (fileType.Contains("application"))
            {
                return "application";
            }
            return "Unknown file type!";
        }

        /// <summary>
        /// Gets folder name of the given file type stored. Currently it can returns Images, Files and Videos. This method should be reviewed if a new folder is added under the wwwroot folder.
        /// </summary>
        /// <param name="fileType">Type of file must be given in a string type.</param>
        /// <returns>Returns the folder name of type string. An error message is returned if it cannot find a matching folder name. </returns>
        public string GetFolderNameOfTheFile(string fileType)
        {
            switch (fileType)
            {
                case "image":
                    return "Images";
                case "text":
                    return "Files";
                case "video":
                    return "Videos";
                default:
                    return "The file type is not supported to upload.";
            }
        }

        /// <summary>
        /// Search for the foldername under given subDirectory folder, that is under the wwwroot directory ,if not found, creates one with the given folder name.
        /// </summary>
        /// <param name="folderName">Foldername should be given for the search and creation of the directory.</param>
        /// <param name="subDirectory">subDirectory states for the any of the directory under the wwwroot. It is nullable.</param>
        public void CheckIfFolderExists(string folderName, string subDirectory)
        {
            var path = Path.Combine($"{_webHostEnvironment.WebRootPath}/{subDirectory}/{folderName}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Search for the foldername under the wwwroot directory if not found, creates one with the given name.
        /// </summary>
        /// <param name="folderName">Foldername should be given for the search and creation of the directory.</param>
        public void CheckIfFolderExists(string folderName)
        {
            var path = Path.Combine($"{_webHostEnvironment.WebRootPath}/{folderName}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Generates file name of type Guid with the file extension.
        /// </summary>
        /// <param name="file">A File must be given in type of IFormFile.</param>
        /// <returns>Returns the filename in string.</returns>
        public string GenerateGuidFileName(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string newFileName = string.Format(@"{0}{1}", Guid.NewGuid(), fileExtension);
            return newFileName;
        }

        /// <summary>
        /// Uploads given file in a matching folder with the file's type. Generates new file name in a Guid type. 
        /// </summary>
        /// <param name="formFile">A file in a IFormFile type must be given.</param>
        /// <returns>If the given file is not null, it returns SuccessDataResult with the data type of FileViewModel, else returns ErrorDataResult.</returns>
        public async Task<IDataResult<FileViewModel>> UploadFile(IFormFile formFile)
        {
            var isNull = CheckIfFileNull(formFile);
            if (isNull)
            {
                var fileType = CheckFileType(formFile);
                var folderName = GetFolderNameOfTheFile(fileType);
                CheckIfFolderExists(uploads,folderName);
                string newFileName = GenerateGuidFileName(formFile);

                var path = Path.Combine($"{_webHostEnvironment.WebRootPath}\\{uploads}\\{folderName}", newFileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                return new SuccessDataResult<FileViewModel>(new FileViewModel
                {
                    File = formFile,
                    //Path = path,
                    Path = Path.Combine(uploads,folderName,newFileName),
                    Name = newFileName,
                    Extension = Path.GetExtension(formFile.FileName),
                    Size = formFile.Length
                });
            }
            return new ErrorDataResult<FileViewModel>();
        }

        /// <summary>
        /// Deletes given file from the folder.
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns>If result in success, return SuccessResult else returns ErrorResult with an error message.</returns>
        public async Task<IResult> DeleteFile(IFormFile formFile)
        {
            var isNull = CheckIfFileNull(formFile);
            if (isNull)
            {
                var fileType = CheckFileType(formFile);
                var folderName = GetFolderNameOfTheFile(fileType);

                var path = Path.Combine($"{_webHostEnvironment.WebRootPath}\\{uploads}\\{folderName}", formFile.FileName);

                if (File.Exists(path))
                {
                    File.Delete(path);
                    return new SuccessResult();
                }
            }
            return new ErrorResult("Dosya silinirken bir hata oluştu.");
        }

        /// <summary>
        /// Deletes the file that has the given path.
        /// </summary>
        /// <param name="filePath">File path must have the folder names from under the Uploads folder in wwwroot folder, with file name and extension.</param>
        /// <returns>If given file exists, it will be deleted and returns SuccessResult else returns ErrorResult with an error message.</returns>
        public async Task<IResult> DeleteFile(string filePath)
        {
            var isNull = String.IsNullOrEmpty(filePath);
            if (!isNull)
            {
                var path = Path.Combine($"{_webHostEnvironment.WebRootPath}\\{uploads}", filePath);

                if (File.Exists(path))
                {
                    File.Delete(path);
                    return new SuccessResult();
                }
            }
            return new ErrorResult("Dosya silinirken bir hata oluştu.");
        }
    }
}
