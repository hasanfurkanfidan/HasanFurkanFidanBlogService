using HasanFurkanFidanBlogService.DataAccess.Interfaces;
using HasanFurkanFidanBlogService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidanBlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleDal _articleDal;
        public ArticlesController(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _articleDal.GetListAsync(null));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _articleDal.GetAsync(p => p.Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Article article)
        {
            await _articleDal.AddAsync(article);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Article article, int? id)
        {
            var updatedArticle = await _articleDal.GetAsync(p => p.Id == id);
            if (updatedArticle == null)
            {
                return BadRequest();
            }
            updatedArticle.CategoryId = article.CategoryId;
            updatedArticle.ContentSummary = article.ContentSummary;
            updatedArticle.Id = article.Id;
            updatedArticle.ImageUrl = article.ImageUrl;
            updatedArticle.ViewCount = article.ViewCount;

            await _articleDal.UpdateAsync(updatedArticle);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var article = await _articleDal.GetAsync(p => p.Id == id);
            if (article == null)
            {
                return BadRequest();
            }
            await _articleDal.DeleteAsync(article);
            return NoContent();
        }
    }
}
