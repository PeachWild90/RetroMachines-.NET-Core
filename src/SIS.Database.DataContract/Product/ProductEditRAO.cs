﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Database.DataContract.Product
{
    public class ProductEditRAO
    {
        public int ProductId { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
    }
}
