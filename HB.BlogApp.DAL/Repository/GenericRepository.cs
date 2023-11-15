using HB.BlogApp.DAL.Abstracts;
using HB.BlogApp.DAL.Contexts;
using HB.BlogApp.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.Repository
{

    public class GenericRepository<T> 
        : IRepository<T> 
        where T : class,IBaseEntity,new()
    {

        private readonly AppDbContext _context;
        private DbSet<T> _dbset;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public T? Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _dbset.Where(filter).FirstOrDefault();
        }

        public T? Get(object id)
        {
            return _dbset.Find(id);
        }

        public List<T> GetAll(bool asnoTracking = true)
        {
            return asnoTracking ? 
                    _dbset.ToList() :
                    _dbset.AsNoTracking().ToList();
                

        }

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _dbset.Where(filter).ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbset.AsQueryable<T>();
        }

        public void Update(T entity)
        {
           _context.Update(entity);
        }
    }
}
