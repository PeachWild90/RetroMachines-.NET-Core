using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Wishlist
{
    public interface IWishlistManager
    {
        Task<bool> CreateWishlist(WishlistCreateDTO dto);
        Task<IEnumerable<WishlistGetAllItemsDTO>> GetWishlistItems(int id);
        Task<bool> WishlistEdit(WishlistEditDTO dto);
        Task<bool> WishlistDelete(int OwnerId);
    }
}
