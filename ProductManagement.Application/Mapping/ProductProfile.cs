using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProductManagement.Application.DTOs;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Mapping
{
    public class ProductProfile : Profile
    {
        //Entity Response DTO

        public ProductProfile()
        {
            // Entity -> Response DTO
            CreateMap<Product, ProductResponseDto>();

            // Create DTO -> Entity
            CreateMap<ProductResponseDto, Product>();

            // Update DTO -> Entity
            CreateMap<ProductUpdateDto, Product>();
        }

    }
}
