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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryDal _categoryDal;
        public CategoriesController(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _categoryDal.GetListAsync(null));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _categoryDal.GetAsync(p => p.Id == id);
            if (category==null)
            {
                return BadRequest();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult>AddAsync(Category category)
        {
            await _categoryDal.AddAsync(category);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateAsync(Category category,int? id)
        {
            var updatedCategory = await _categoryDal.GetAsync(p => p.Id == id);
            if (updatedCategory==null)
            {
                return BadRequest();
            }
            updatedCategory.Name = category.Name;
            await _categoryDal.UpdateAsync(updatedCategory);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAsync(int id)
        {
            var category = await _categoryDal.GetAsync(p => p.Id == id);
            if (category==null)
            {
                return BadRequest();
            }
            await _categoryDal.DeleteAsync(category);
            return NoContent();
        }
    }
}
