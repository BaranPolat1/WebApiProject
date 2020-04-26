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
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost("add")]
        public IActionResult Add(Post post)
        {
            var result = _postService.Add(post);
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
        public IActionResult Update(Post post)
        {

            var result = _postService.Update(post);
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
        public IActionResult Delete(Post post)
        {
            var result = _postService.Add(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _postService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getbyauthor")]
        public IActionResult GetList(int authorId)
        {
            var result = _postService.GetByAuthor(authorId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _postService.GetByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}