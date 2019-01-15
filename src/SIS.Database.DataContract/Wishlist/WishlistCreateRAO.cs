using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.DataContract.Wishlist
{
    public class WishlistCreateRAO
    {
        public int TransactionalId { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
    }
}
