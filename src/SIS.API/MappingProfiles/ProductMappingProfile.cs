using AutoMapper;
using RedStarter.API.DataContract.Product;
using RedStarter.Business.DataContract.Product;
using RedStarter.Business.DataContract.Wishlist;
using RedStarter.Database.DataContract.Product;
using RedStarter.Database.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedStarter.API.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCreateRequest, ProductCreateDTO>();
            CreateMap<ProductCreateDTO, ProductCreateRAO>();
            CreateMap<ProductCreateRAO, ProductEntity>();

            CreateMap<ProductEntity, ProductGetListItemRAO>();
            CreateMap<ProductGetListItemRAO, ProductGetListItemDTO>();
            CreateMap<ProductGetListItemDTO, ProductResponse>();

            CreateMap<ProductEditRequest, ProductEditDTO>();
            CreateMap<ProductEditDTO, ProductEditRAO>();

            CreateMap<ProductGetListItemRAO, WishlistGetAllItemsDTO>();
        }
    }
}
