using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Wishlist
{
    public class WishlistResponse
    {
        public int Name { get; set; }
        public int WishlistId { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
    }
}
