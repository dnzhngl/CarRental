using CarRental.Business.Abstract;
using CarRental.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _departmentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _departmentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Department department)
        {
            var result = _departmentService.Add(department);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Department department)
        {
            var result = _departmentService.Delete(department);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Department department)
        {
            var result = _departmentService.Update(department);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
