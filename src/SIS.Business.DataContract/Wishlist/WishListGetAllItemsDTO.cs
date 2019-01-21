using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Wishlist
{
    public class WishlistItemsDTO
    {
        //public int ProductEntityId { get; set; }
        public int WishlistId { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
    }
}
