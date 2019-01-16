
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Product
{
    public interface IProductManager
    {
        Task<bool> CreateProduct(ProductCreateDTO dto); 
        Task<IEnumerable<ProductGetListItemDTO>> GetProducts(); //preexisting so no 
        Task<bool> ProductEdit(ProductEditDTO dto);
        Task<ProductGetListItemDTO> GetProductById(int ProductEntityId);
        Task<bool> ProductDelete(int ProductEntityId);
        string GetUserNameByOwnerId(int id);
    }
}
