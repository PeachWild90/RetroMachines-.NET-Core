using AutoMapper;
using RedStarter.Business.DataContract.Product;
using RedStarter.Database.DataContract.Authorization.Interfaces;
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
        private readonly IAuthRepository _authRepository;

        public ProductManager(IMapper mapper, IProductRepository repository, IAuthRepository authRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _authRepository = authRepository;
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
            var raos = await _repository.GetProducts();
            var dtos = _mapper.Map<IEnumerable<ProductGetListItemDTO>>(raos);
            foreach (ProductGetListItemDTO dto in dtos)
            {
                dto.UserName = (await _authRepository.GetUserById(dto.OwnerId)).UserName;
            }
            //TODO: 
            //TODO: Get name by product 
            

            return dtos;
        }

        public async Task<ProductGetListItemDTO> GetProductById(int id)
        {
            var query = await _repository.GetProductById(id);
            var dto = _mapper.Map<ProductGetListItemDTO>(query);
            {
                dto.UserName = (await _authRepository.GetUserById(dto.OwnerId)).UserName;
            }
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
