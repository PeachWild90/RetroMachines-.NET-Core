using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Wishlist
{
    public class WishlistGetAllItemsRequest
    {
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
        public int TransactionalId { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
