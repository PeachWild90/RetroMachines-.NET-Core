using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.DataContract.Product
{
    public interface IProductRepository
    {
        Task<bool> CreateProduct(ProductCreateRAO rao);
    }
}
