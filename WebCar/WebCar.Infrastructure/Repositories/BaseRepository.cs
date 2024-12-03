using Microsoft.EntityFrameworkCore;
using WebCar.Domain.Core;
using WebCar.Domain.Repositories;
using WebCar.Infrastructure.Data;

namespace WebCar.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        protected readonly ApplicationDataContext _dataContext;
        protected readonly DbSet<TEntity> _entity;

        public BaseRepository(ApplicationDataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
            _entity = _dataContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entity;
        }

        public virtual void Add(TEntity obj)
        {
            _entity.Add(obj);
        }

        public virtual TEntity Get(TKey id)
        {
            return _entity.Find(id);
        }

        public virtual void Update(TEntity obj)
        {
            _entity.Update(obj);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
