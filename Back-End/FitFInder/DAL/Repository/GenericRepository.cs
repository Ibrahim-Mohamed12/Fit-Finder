using DAL.Data.Context;
using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFinderProject.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly FitFinderDBContext _context;

        public GenericRepository(FitFinderDBContext context)
        {
            _context = context;
        }

        public Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync().ContinueWith(task => task.Result.AsEnumerable());
        }

        public Task<T> GetByIdAsync(string id)
        {
            return _context.Set<T>().FindAsync(id).AsTask();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
