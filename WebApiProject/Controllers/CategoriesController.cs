using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("details")]
        public IActionResult Details(int Id)
        {
            var result = _categoryService.GetById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("add")]
        public IActionResult Add(Category category)
        {

            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(Category category)
        {

            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Category category)
        {

            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}