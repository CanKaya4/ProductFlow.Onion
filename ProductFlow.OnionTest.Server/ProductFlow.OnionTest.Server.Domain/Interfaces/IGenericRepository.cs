using ProductFlow.OnionTest.Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProductFlow.OnionTest.Server.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(
         Expression<Func<T, bool>> filter = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, // Sıralama için
         int? skip = null, // Kaç veri atlanacak
         int? take = null, // Kaç veri alınacak
         params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdSlug(string slug, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T Entity);

    }
}
