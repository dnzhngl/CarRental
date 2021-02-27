using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using CarRental.WebApi.Helpers.Abstract;
using CarRental.WebApi.Models;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarRental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        private readonly IFileHelper _fileHelper;
        public CarImagesController(ICarImageService carImagesService, IFileHelper fileHelper)
        {
            _carImageService = carImagesService;
            _fileHelper = fileHelper;
        }

        [HttpGet("GetAllByCar")]
        public IActionResult GetAllByCar(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpPost("Add")]
        //public IActionResult Add(CarImage carImage)
        //{
        //    var result = _carImageService.Add(carImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromForm] CarImage carImage, IFormFile file)
        {
            var addedFile = await _fileHelper.UploadFile(file);
            if (addedFile.Success)
            {
                carImage.ImagePath = addedFile.Data.Path;
                var result = _carImageService.Add(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(addedFile);
            // _fileHelper.DeleteFile(addedFile.Data.File);
        }

        [HttpPost("MultipleUpload")]
        public async Task<IActionResult> AddMultipleAsync([FromForm] CarImage carImage, IFormFile[] files)
        {
            IResult result = null;
            if (files.Length > 0 && files.Length < 6)
            {
                foreach (var file in files)
                {
                    var addedFile = await _fileHelper.UploadFile(file);
                    if (!addedFile.Success)
                    {
                        return BadRequest(addedFile);
                    }
                    CarImage image = new CarImage
                    {
                        CarId = carImage.CarId,
                        ImagePath = addedFile.Data.Path
                    };
                    result = _carImageService.Add(image);
                    if (!result.Success)
                    {
                        return BadRequest(result);
                    }
                }
                return Ok(result);
            }
            // _fileHelper.DeleteFile(addedFile.Data.File);
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var isDeleted = _fileHelper.DeleteFile(carImage.ImagePath);
            if (isDeleted.Result.Success)
            {
                var result = _carImageService.Delete(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(isDeleted.Result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromForm] CarImage carImage, IFormFile file)
        {
            var isDeleted = _fileHelper.DeleteFile(carImage.ImagePath);
            if (isDeleted.Result.Success)
            {
                var addedFile = await _fileHelper.UploadFile(file);
                carImage.ImagePath = addedFile.Data.Path;
                var result = _carImageService.Update(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(isDeleted.Result);
        }
    }
}
