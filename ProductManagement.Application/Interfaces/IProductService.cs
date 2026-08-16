using ProductManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();

        Task<ProductResponseDto?> GetByIdAsync(int id);

        Task<ProductResponseDto> CreateAsync(ProductCreateDto dto);

        Task<ProductResponseDto?> UpdateAsync(int id,ProductUpdateDto dto);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ProductResponseDto>>
            GetProductsByCategoryAsync(string category);
    }
}
