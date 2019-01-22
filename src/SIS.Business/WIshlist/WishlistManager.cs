using AutoMapper;
using RedStarter.API.DataContract.Product;
using RedStarter.Business.DataContract.Product;
using RedStarter.Business.DataContract.Wishlist;
using RedStarter.Database.DataContract.Authorization.Interfaces;
using RedStarter.Database.DataContract.Product;
using RedStarter.Database.DataContract.Wishlist;
using RedStarter.Database.Wishlist;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.WIshlist
{
    public class WishlistManager : IWishlistManager
    {
        private readonly IMapper _mapper;
        private readonly IWishlistRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IAuthRepository _authRepository;

        public WishlistManager(IMapper mapper, IWishlistRepository repository, IProductRepository productRepository, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _productRepository = productRepository;
            _authRepository = authRepository;
        }

        public async Task<bool> CreateWishlist(WishlistCreateDTO dto)
        {
            var rao = _mapper.Map<WishlistCreateRAO>(dto);

            if (await _repository.CreateWishlist(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WishlistItemsDTO>> GetWishlistItems(int id)
        {
            var wishlistRAO = await _repository.GetWishlistItems(id); //this goes into repository with the ownerId
            

            var collection = new List<ProductGetListItemRAO>();
            foreach (var singleWishListItem in wishlistRAO)
            {
                var productRAO = await _productRepository.GetProductById(singleWishListItem.ProductId);
                collection.Add(productRAO);
            }

            var itemsToReturn = _mapper.Map<IEnumerable<WishlistItemsDTO>>(collection);

            foreach (var dto in itemsToReturn)
            {
                dto.UserName = (await _authRepository.GetUserById(dto.OwnerId)).UserName;
            }

            var i = 0;
            var j = 0;

            foreach (var item in itemsToReturn)
            {
                foreach (var itemRAO in wishlistRAO)
                {
                    if (i == j)
                    {
                        item.TransactionalId = itemRAO.TransactionalId;
                    }

                    j++;
                }
                i++;
                j = 0;
            }

            return itemsToReturn;
            throw new Exception();
        }

        public async Task<WishlistItemDTO> GetWishlistById(int id)
        {
            var query = await _repository.GetWishlistById(id);
            var dto = _mapper.Map<WishlistItemDTO>(query);
        
            dto.UserName = (await _authRepository.GetUserById(dto.OwnerId)).UserName;
            
            return dto;
        }

        public async Task<bool> WishlistEdit(WishlistEditDTO dto)
        {
            var rao = _mapper.Map<WishlistEditRAO>(dto);

            if (await _repository.WishlistEdit(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<bool> WishlistDelete(int id)
        {
            if (await _repository.WishlistDelete(id))
                return true;

            throw new Exception();
        }
    }


}
