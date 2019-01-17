using AutoMapper;
using RedStarter.Business.DataContract.Wishlist;
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

        public WishlistManager(IMapper mapper, IWishlistRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateWishlist(WishlistCreateDTO dto)
        {
            var rao = _mapper.Map<WishlistCreateRAO>(dto);

            if (await _repository.CreateWishlist(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WishlistGetAllItemsDTO>> GetWishlistItems(int userId)
        {
            var rao = await _repository.GetWishlistItems(userId);
            var dto = _mapper.Map<IEnumerable<WishlistGetAllItemsDTO>>(rao);

            return dto;
        }

        public async Task<WishlistGetAllItemsDTO> GetWishlistById(int id)
        {
            var query = await _repository.GetWishlistById(id);
            var dto = _mapper.Map<WishlistGetAllItemsDTO>(query);

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
