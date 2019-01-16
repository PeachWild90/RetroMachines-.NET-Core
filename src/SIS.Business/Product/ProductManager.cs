using AutoMapper;
using RedStarter.Business.DataContract.Product;
using RedStarter.Database.DataContract.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.Product
{
    public class ProductManager : IProductManager //interface states that if you have a method inside of here you have to have an implementation. YOU HAVE TO HAVE ALL THE METHODS IN HERE!!!
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public ProductManager(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateProduct(ProductCreateDTO dto) //this is a signature for a method. Return type, name, and parameters
        {
            var rao = _mapper.Map<ProductCreateRAO>(dto);

            if (await _repository.CreateProduct(rao))
                return true;

            throw new NotImplementedException(); //here is the actual implementation. It is what happens BETWEEN the curly braces
        }

        public async Task<IEnumerable<ProductGetListItemDTO>> GetProducts()
        {
            var rao = await _repository.GetProducts();

            //TODO: 
            //TODO: Get name by product 

            var dto = _mapper.Map<IEnumerable<ProductGetListItemDTO>>(rao);

            return dto;
        }

        public string GetUserNameByOwnerId(int id)
        {
             return _repository.GetUserNameByOwnerId(id);

        }

        public async Task<ProductGetListItemDTO> GetProductById(int id)
        {
            var query = await _repository.GetProductById(id);
            var dto = _mapper.Map<ProductGetListItemDTO>(query);

            return dto;
        }

        public async Task<bool> ProductEdit(ProductEditDTO dto)
        {
            var rao = _mapper.Map<ProductEditRAO>(dto);

            if (await _repository.ProductEdit(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<bool> ProductDelete(int id)
        {
            if (await _repository.ProductDelete(id))
                return true;

            throw new Exception();
            //var rao = await _repository.ProductDelete(id);
            //var dto = _mapper.Map<IEnumerable<ProductGetListItemDTO>>(rao);

            //return dto;
        }
    }
}
