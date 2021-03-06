﻿using RedStarter.API.DataContract.Product;
using RedStarter.Business.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Wishlist
{
    public interface IWishlistManager
    {
        Task<bool> CreateWishlist(WishlistCreateDTO dto);
        Task<IEnumerable<WishlistItemsDTO>> GetWishlistItems(int id);
        Task<bool> WishlistEdit(WishlistEditDTO dto);
        Task<bool> WishlistDelete(int OwnerId);
        Task <WishlistItemDTO>GetWishlistById(int id);
    }
}
