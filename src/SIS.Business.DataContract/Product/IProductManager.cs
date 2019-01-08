using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Product
{
    public interface IProductManager
    {
        Task<bool> CreateProduct(ProductCreateDTO dto); //we have a single interface method in an IProduct Manager
        Task<IEnumerable<ProductGetListItemDTO>> GetProducts(); //preexisting so no 
        
    }
}
