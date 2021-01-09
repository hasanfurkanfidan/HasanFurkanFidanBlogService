using HasanFurkanFidanBlogService.DataAccess.Interfaces;
using HasanFurkanFidanBlogService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidanBlogService.DataAccess.EntityFramework.Repositories
{
    public class CategoryDal:GenericDal<Category>,ICategoryDal
    {
    }
}
