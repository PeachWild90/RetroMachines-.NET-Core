using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Wishlist
{
    public class WishlistGetAllItemsDTO
    {
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
    }
}
