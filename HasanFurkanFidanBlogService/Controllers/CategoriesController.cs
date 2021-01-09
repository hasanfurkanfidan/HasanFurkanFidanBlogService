using HasanFurkanFidanBlogService.DataAccess.Interfaces;
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

    }
}
