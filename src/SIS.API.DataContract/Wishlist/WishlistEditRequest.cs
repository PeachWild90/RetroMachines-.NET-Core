using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Wishlist
{
    public class WishlistEditRequest
    {
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
    }
}
