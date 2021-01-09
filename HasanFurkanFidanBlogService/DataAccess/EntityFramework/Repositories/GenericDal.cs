using HasanFurkanFidanBlogService.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HasanFurkanFidanBlogService.DataAccess.EntityFramework.Repositories
{
    public class GenericDal<TEntity> : IGenericDal<TEntity> where TEntity : class, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new Context();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new Context();
            context.Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new Context();
            return await context.Set<TEntity>().FindAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new Context();
            var list = new List<TEntity>();
            if (filter != null)
            {
                list = await context.Set<TEntity>().Where(filter).ToListAsync();
            }
            list = await context.Set<TEntity>().ToListAsync();
            return list;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new Context();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
