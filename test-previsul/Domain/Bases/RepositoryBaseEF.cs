using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using test_previsul.Infra.Data.Context;

namespace test_previsul.Domain.Bases
{
    public class RepositoryBaseEF<TEntity> : IDisposable where TEntity : class
    {
        protected readonly DmContext ctx;
        public RepositoryBaseEF(DmContext sisnCtx = null)
        {
            if (sisnCtx == null)
                this.ctx = new DmContext();
            else
                this.ctx = sisnCtx;

        }

        public async virtual Task<int> Insert(TEntity item)
        {
            ctx.Set<TEntity>().Add(item);
            return await ctx.SaveChangesAsync();
        }

        public async virtual Task<int> Delete(TEntity item)
        {
            ctx.Entry(item).State = EntityState.Deleted;
            return await ctx.SaveChangesAsync();
        }

        public async virtual Task<int> Edit(TEntity item)
        {
            ctx.Entry(item).State = EntityState.Modified;
            return await ctx.SaveChangesAsync();
        }

        public async virtual Task<TEntity> SearchObject(Expression<Func<TEntity, bool>> expression, string[] Includes = null)
        {
            return (await GetQueryable(expression, Includes)).FirstOrDefault();
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> expression = null, string[] Includes = null, int take = 0)
        {
            return (await GetQueryable(expression, Includes, take)).ToList();
        }


        public async Task<IQueryable<TEntity>> GetQueryable(Expression<Func<TEntity, bool>> expression = null, string[] Includes = null, int take = 0)
        {
            IQueryable<TEntity> result = ctx.Set<TEntity>();

            if (Includes != null)
            {
                foreach (var item in Includes)
                {
                    result = result.Include(item);
                }
            }
            if (expression != null)
            {
                result = result.Where(expression);
            }
            if (take > 0)
            {
                result = result.Take(take);
            }
            return result;

        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
