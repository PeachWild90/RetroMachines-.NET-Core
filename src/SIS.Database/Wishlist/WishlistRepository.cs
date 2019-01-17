using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedStarter.Database.Contexts;
using RedStarter.Database.DataContract.Wishlist;
using RedStarter.Database.Entities.WIshlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.Wishlist
{
        public class WishlistRepository : IWishlistRepository
        {
            private readonly SISContext _context;
            private readonly IMapper _mapper;

            public WishlistRepository(SISContext context, IMapper mapper)
            {
            _context = context;
            _mapper = mapper;
            }

        public async Task<bool> CreateWishlist(WishlistCreateRAO rao)
        {
            var entity = _mapper.Map<WishlistEntity>(rao);
            await _context.WishlistTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<WishlistGetAllItemsRAO> GetWishlistById(int id)
        {
            var query = await _context.WishlistTableAccess.SingleAsync(x => x.TransactionalId == id);
            var rao = _mapper.Map<WishlistGetAllItemsRAO>(query);

            return rao;
        }

        public async Task<IEnumerable<WishlistGetAllItemsRAO>> GetWishlistItems(int userId)
        {
            var query = await _context.WishlistTableAccess.Where(x => x.OwnerId == userId).ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<WishlistGetAllItemsRAO>>(query);

            return rao;
        }

        public async Task<bool> WishlistDelete(int id)
        {
            var query = await _context.WishlistTableAccess.SingleAsync(x => x.TransactionalId == id); //TRANSACTIONALID
            _context.WishlistTableAccess.Remove(query);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> WishlistEdit(WishlistEditRAO rao)
        {
            var entity = _context.WishlistTableAccess.SingleAsync(x => x.TransactionalId == rao.ProductId);
            entity.Result.ProductId = rao.ProductId;
            entity.Result.OwnerId = rao.OwnerId;

            return await _context.SaveChangesAsync() == 1;
        }
    }
    }


