using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.InfrastructureLayer.Data;

namespace ProductManagement.InfrastructureLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            //throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();

            //throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
            //throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
           // throw new NotImplementedException();
        }
    }
}
