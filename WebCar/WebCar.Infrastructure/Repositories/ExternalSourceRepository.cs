using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebCar.Domain.Core;
using WebCar.Domain.Repositories;
using WebCar.Infrastructure.Data;

namespace WebCar.Infrastructure.Repositories;

public sealed class ExternalSourceRepository<TEntity, TKey> : IExternalSourceRepository<TEntity, TKey> where TEntity : Entity<TKey>, IExternalSource
{
    private readonly ApplicationDataContext _dataContext;
    private readonly DbSet<TEntity> _entity;

    public ExternalSourceRepository(ApplicationDataContext context)
    {
        _dataContext = context ?? throw new ArgumentNullException(nameof(context));
        _entity = _dataContext.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _entity.Add(entity);
        //ChangeEnumerationsToUnchanged();
    }

    public void Delete(TEntity entity)
    {
        _entity.Remove(entity);
    }

    public TEntity Get(TKey id)
    {
        return _entity.Find(id);
    }

    public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate)
    {
        return _entity.Where(predicate);
    }

    public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        var item = await _entity.FindAsync(new object[] { id, cancellationToken }, cancellationToken: cancellationToken);
        return item;
    }

    public int Save()
    {
        return _dataContext.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _entity.Update(entity);
    }

    //private void ChangeEnumerationsToUnchanged()
    //{
    //    var entries = _dataContext.ChangeTracker.Entries();
    //    foreach (var item in entries)
    //    {
    //        var isEnumeration = item.Entity is System.IO.Enumeration;
    //        if (isEnumeration)
    //            item.State = EntityState.Unchanged;
    //    }
}
