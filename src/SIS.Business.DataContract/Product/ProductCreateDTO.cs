using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Product
{
    public class ProductCreateDTO
    {
        public int Year { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
