using AutoMapper;
using RedStarter.API.DataContract.Wishlist;
using RedStarter.Business.DataContract.Wishlist;
using RedStarter.Database.DataContract.Product;
using RedStarter.Database.DataContract.Wishlist;
using RedStarter.Database.Entities.WIshlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedStarter.API.MappingProfiles
{
    public class WishlistMappingProfile : Profile 
    {
        public WishlistMappingProfile()
        {
            CreateMap<WishlistCreateRequest, WishlistCreateDTO>();
            CreateMap<WishlistCreateDTO, WishlistCreateRAO>();
            CreateMap<WishlistCreateRAO, WishlistEntity>().ForMember(x => x.TransactionalId, opt => opt.Ignore());

            CreateMap<WishlistEntity, WishlistGetAllItemsRAO>();
            CreateMap<WishlistGetAllItemsRAO, WishlistItemsDTO>();
            CreateMap<WishlistItemsDTO, WishlistGetAllItemsRequest>();
            CreateMap<WishlistItemsDTO, WishlistResponse>();

            CreateMap<WishlistEditRequest, WishlistEditDTO>();
            CreateMap<WishlistEditDTO, WishlistEditRAO>();
            CreateMap<WishlistItemsDTO, ProductGetListItemRAO>().ForMember(x => x.Year, opt => opt.Ignore())
                                                                .ForMember(x => x.Type, opt => opt.Ignore());
            CreateMap<ProductGetListItemRAO, WishlistItemsDTO>().ForMember(x => x.UserName, opt => opt.Ignore());
        }
    }
}
