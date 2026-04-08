using AutoMapper;
using InventoryTrackerAPI.Models;
using InventoryTrackerAPI.DTOs;

namespace InventoryTrackerAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}