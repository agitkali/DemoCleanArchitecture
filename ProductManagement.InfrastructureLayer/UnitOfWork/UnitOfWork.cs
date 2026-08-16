using ProductManagement.Application.Interfaces;
using ProductManagement.InfrastructureLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.InfrastructureLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
       
        private readonly ApplicationDbContext _context;
        public IProductRepository Products { get; }

        public UnitOfWork(ApplicationDbContext dbContext, IProductRepository productRepository)
        {
            _context = dbContext;
            Products = productRepository;
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
           // throw new NotImplementedException();
        }
    }
}
