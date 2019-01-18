using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.DataContract.Product
{
   public class ProductRAO
    {
        public int WishlistId { get; set; }
        public int OwnerId { get; set; }
        public int ProductId { get; set; }
        public int Name { get; set; }
        public int Year { get; set; }
    }
}
