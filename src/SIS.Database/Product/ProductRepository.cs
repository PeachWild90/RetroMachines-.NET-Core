using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedStarter.Database.Contexts;
using RedStarter.Database.DataContract.Product;
using RedStarter.Database.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace RedStarter.Database.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly SISContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(SISContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> CreateProduct(ProductCreateRAO rao)
        {

            var entity = _mapper.Map<ProductEntity>(rao);
            await _context.ProductTableAccess.AddAsync(entity);

            return await _context.SaveChangesAsync() == 1;

        }

        public async Task<IEnumerable<ProductGetListItemRAO>> GetProducts()
        {

            var query = await _context.ProductTableAccess.ToArrayAsync();
            var array = _mapper.Map<IEnumerable<ProductGetListItemRAO>>(query);

            return array;

        }

        public async Task<ProductGetListItemRAO> GetProductById(int id)
        {
            var query = await _context.ProductTableAccess.SingleAsync(x => x.ProductEntityId == id);
            var rao = _mapper.Map<ProductGetListItemRAO>(query);

            return rao;
        }

        public async Task<bool> ProductEdit(ProductEditRAO rao)
        {
            var entity = await _context.ProductTableAccess.SingleAsync(x => x.ProductEntityId == rao.ProductEntityId);
            entity.Year = rao.Year;
            entity.Name = rao.Name;
            entity.Type = rao.Type;
            entity.Condition = rao.Condition;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> ProductDelete(int id)
        {
            var query = await _context.ProductTableAccess.SingleAsync(x => x.ProductEntityId == id);
             _context.ProductTableAccess.Remove(query);

            return await _context.SaveChangesAsync() == 1;
        }

       
    }
}
