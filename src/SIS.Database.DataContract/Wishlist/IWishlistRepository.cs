﻿using RedStarter.Database.DataContract.Wishlist;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.Wishlist
{
    public interface IWishlistRepository
    {
        Task<bool> CreateWishlist(WishlistCreateRAO rao);
        Task<IEnumerable<WishlistGetAllItemsRAO>> GetWishlistItems(int userId);
        Task<bool> WishlistEdit(WishlistEditRAO dto);
        Task<bool> WishlistDelete(int OwnerId);
        Task<WishlistGetAllItemsRAO> GetWishlistById(int id);
    }
}
