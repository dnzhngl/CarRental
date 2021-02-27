using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApi.Models
{
    public class CarImageViewModel
    {
        public CarImage CarImage { get; set; }
        public IFormFile File { get; set; }
    }
}
