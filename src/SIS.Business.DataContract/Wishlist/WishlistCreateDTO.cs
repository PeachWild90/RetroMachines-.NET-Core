using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Wishlist
{
    public class WishlistCreateDTO
    {
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
    }
}
