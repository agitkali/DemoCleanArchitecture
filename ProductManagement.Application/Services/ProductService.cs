using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Application;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using AutoMapper;
using ProductManagement.Domain.Entities;



namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Create
        public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
             await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductResponseDto>(product);
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var products = await _unitOfWork.Products.GetByIdAsync(id);

            if(products == null)
                return false;

            _unitOfWork.Products.Delete(products);
            await _unitOfWork.SaveChangesAsync();
            return true;

            //throw new NotImplementedException();
        }

        // GET ALL
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);

            //throw new NotImplementedException();
        }


        //Get By ID
        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return _mapper.Map<ProductResponseDto?>(product);
           // throw new NotImplementedException();
        }

        public async Task<ProductResponseDto?> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            _mapper.Map(dto, product);
            
              _unitOfWork.Products.Update(product);
            _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductResponseDto>(product);
            

            //throw new NotImplementedException();
        }
    }
}
