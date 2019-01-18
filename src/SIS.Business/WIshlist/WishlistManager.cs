using AutoMapper;
using RedStarter.Business.DataContract.Wishlist;
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

        public WishlistManager(IMapper mapper, IWishlistRepository repository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<bool> CreateWishlist(WishlistCreateDTO dto)
        {
            var rao = _mapper.Map<WishlistCreateRAO>(dto);

            if (await _repository.CreateWishlist(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WishlistGetAllItemsDTO>> GetWishlistItems(int id)
        {
            var wishlistRAO = await _repository.GetWishlistItems(id); //this goes into repository with the ownerId
            

            var collection = new List<ProductGetListItemRAO>();
            foreach (var singleWishListItem in wishlistRAO)
            {
                var productRAO = await _productRepository.GetProductById(singleWishListItem.ProductId);
                collection.Add(productRAO);
            }

            var itemsToReturn = _mapper.Map<IEnumerable<WishlistGetAllItemsDTO>>(collection);
            return itemsToReturn;
            throw new Exception();

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
