using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace test_previsul.Domain.Bases
{
    public class ServiceBase<TEntity, TViewModel> : IDisposable where TEntity : class where TViewModel : class
    {
        public string resultMessage = "error!";
        private bool disposed = false;

        ~ServiceBase()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
        }

        public virtual async Task<int> Insert(TViewModel item)
        {
            using (var service = new RepositoryBaseEF<TEntity>())
            {
                return await service.Insert(Mapper.Map<TEntity>(item));
            }
        }

        public virtual async Task<int> Edit(TViewModel item)
        {
            using (var service = new RepositoryBaseEF<TEntity>())
            {
                return await service.Edit(Mapper.Map<TEntity>(item));
            }
        }

        public virtual async Task<int> Delete(TViewModel item)
        {
            using (var service = new RepositoryBaseEF<TEntity>())
            {
                return await service.Delete(Mapper.Map<TEntity>(item));
            }
        }

        public virtual async Task<TViewModel> SearchObject(Expression<Func<TEntity, bool>> expression, String[] Includes = null)
        {
            using (var service = new RepositoryBaseEF<TEntity>())
            {
                return Mapper.Map<TViewModel>(await service.SearchObject(expression, Includes));
            }
        }

        public virtual async Task<List<TViewModel>> ListAll(Expression<Func<TEntity, bool>> expression = null, String[] Includes = null)
        {
            using (var service = new RepositoryBaseEF<TEntity>())
            {
                return Mapper.Map<List<TViewModel>>(await service.GetList(expression, Includes));
            }
        }
    }
}
