using Microsoft.EntityFrameworkCore;
using ProductFlow.OnionTest.Server.Domain.Entities;
using ProductFlow.OnionTest.Server.Domain.Interfaces;
using ProductFlow.OnionTest.Server.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProductFlow.OnionTest.Server.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T enitity)
        {
            await _context.Set<T>().AddAsync(enitity);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? skip = null,
        int? take = null,
        params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if(filter != null)
                query = query.Where(filter);

            foreach(var item in includes)
                query = query.Include(item);

            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue) query = query.Skip(skip.Value);
            if (take.HasValue) query = query.Take(take.Value);

 

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return await query.FirstOrDefaultAsync(x => EF.Property<Guid>(x, "Id") == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task<T> GetByIdSlug(string slug, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var item in includes)
            {
                query.Include(item);
            }
            return await query.FirstOrDefaultAsync(x => EF.Property<string>(x, "Slug") == slug);
        }
    }
}
