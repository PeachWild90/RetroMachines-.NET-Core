using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Product
{
    public class ProductResponse
    {
        public int ProductEntityId { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int OwnerId { get; set; }
        public string UserName { get; set; }
        //TODO 1: name property

    }
}
