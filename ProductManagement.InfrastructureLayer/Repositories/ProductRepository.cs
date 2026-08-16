using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain;
using ProductManagement.Domain.Entities;
using ProductManagement.InfrastructureLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.InfrastructureLayer.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) 
        {
            
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _context.Products.Where(x => x.Stock > 0)
                .AsNoTracking().ToListAsync();
           
        }
    }
}
