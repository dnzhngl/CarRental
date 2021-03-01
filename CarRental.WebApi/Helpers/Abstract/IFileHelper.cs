using CarRental.WebApi.Models;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApi.Helpers.Abstract
{
    public interface IFileHelper
    {
        /// <summary>
        /// Check if the file is null or not.
        /// </summary>
        /// <param name="file">Takes an IFormFile type paramter.</param>
        /// <returns>Returns false if the file is null and returns true if the file is not null.</returns>
        bool CheckIfFileNull(IFormFile file);

        /// <summary>
        /// Checks file type by file's content type.
        /// </summary>
        /// <param name="file">Takes an IFormFile type paramter.</param>
        /// <returns>Returns the given file's type in string type. The type of file should be one of these image, text, audio, video or application types. If it cannot find the type of the given file, a string type error message is returned. </returns>
        string CheckFileType(IFormFile file);

        /// <summary>
        /// Gets folder name of the given file type stored. Currently it can returns Images, Files and Videos. This method should be reviewed if a new folder is added under the wwwroot folder.
        /// </summary>
        /// <param name="fileType">Type of file must be given in a string type.</param>
        /// <returns>Returns the folder name of type string. An error message is returned if it cannot find a matching folder name. </returns>
        string GetFolderNameOfTheFile(string fileType);

        /// <summary>
        /// Search for the foldername under the wwwroot directory if not found, creates one with the given name.
        /// </summary>
        /// <param name="folderName">Foldername should be given for the search and creation of the directory.</param>
        void CheckIfFolderExists(string folderName);

        /// <summary>
        /// Search for the foldername under given subDirectory folder, that is under the wwwroot directory ,if not found, creates one with the given folder name.
        /// </summary>
        /// <param name="folderName">Foldername should be given for the search and creation of the directory.</param>
        /// <param name="subDirectory">subDirectory states for the any of the directory under the wwwroot. It is nullable.</param>
        void CheckIfFolderExists(string folderName, string subDirectory);

        /// <summary>
        /// Check for the given file's type and foldername.
        /// </summary>
        /// <param name="file">File must be given in the type of IFormFile.</param>
        /// <param name="folderName">out string type parameter is returning.</param>
        /// <returns>Returns file type with folder name and related foldername with the parameter of out type.</returns>
        public string CheckFileTypeWithFolderName(IFormFile file, out string folderName);

        /// <summary>
        /// Generates file name of type Guid with the file extension.
        /// </summary>
        /// <param name="file">A File must be given in type of IFormFile.</param>
        /// <returns>Returns the filename in string.</returns>
        string GenerateGuidFileName(IFormFile file);

        /// <summary>
        /// Uploads given file in a matching folder with the file's type. Generates new file name in a Guid type. 
        /// </summary>
        /// <param name="formFile">A file in a IFormFile type must be given.</param>
        /// <returns>If the given file is not null, it returns SuccessDataResult with the data type of FileViewModel, else returns ErrorDataResult.</returns>
        Task<IDataResult<FileViewModel>> UploadFile(IFormFile formFile);

        /// <summary>
        /// Deletes given file from the folder.
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns>If result in success, return SuccessResult else returns ErrorResult with an error message.</returns>
        Task<IResult> DeleteFile(IFormFile formFile);

        /// <summary>
        /// Deletes the file that has the given path.
        /// </summary>
        /// <param name="filePath">File path must have the folder names from under the Uploads folder in wwwroot folder, with file name and extension.</param>
        /// <returns>If given file exists, it will be deleted and returns SuccessResult else returns ErrorResult with an error message.</returns>
        Task<IResult> DeleteFile(string filePath);
    }
}
