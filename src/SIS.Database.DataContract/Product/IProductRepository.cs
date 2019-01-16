using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.DataContract.Product
{
    public interface IProductRepository
    {
        Task<bool> CreateProduct(ProductCreateRAO rao);
        Task<IEnumerable<ProductGetListItemRAO>> GetProducts();
        Task<bool> ProductEdit(ProductEditRAO rao);
        Task<ProductGetListItemRAO> GetProductById(int id);
        Task<bool> ProductDelete(int ProductEntityId);
        string GetUserNameByOwnerId(int id);
    }
}
