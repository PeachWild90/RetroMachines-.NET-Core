using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Product;
using RedStarter.Business.DataContract.Product;

namespace RedStarter.API.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductManager _manager;

        public ProductController(IMapper mapper, IProductManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }


        [HttpPost]
        [Authorize(Roles = "Admin, User")] //the only peoeple who can add a product are people that are authorized. THey have to match the SeedRepository
        public async Task<IActionResult> PostProduct(ProductCreateRequest request)
        {

            if (!ModelState.IsValid) //want this to check 
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); //what this does: handy little tool to see who is associated with the incoming request. Takes token, goes into DB and checks it out
            var dto = _mapper.Map<ProductCreateDTO>(request);
            dto.DateCreated = DateTime.Now;
            dto.OwnerId = identityClaimNum;

            if (await _manager.CreateProduct(dto))
                return StatusCode(201);

            throw new Exception();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetProducts()
        {
            if (!ModelState.IsValid) //want this to check 
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = await _manager.GetProducts();
            var response = _mapper.Map<IEnumerable<ProductResponse>>(dto);

            return Ok(response); //TODO : Handle exceptions
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = await _manager.GetProductById(id);
            var response = _mapper.Map<ProductResponse>(dto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ProductEdit(int id, ProductEditRequest request)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = _mapper.Map<ProductEditDTO>(request);

            if (await _manager.ProductEdit(dto))
                return StatusCode(201);

            throw new Exception();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ProductDelete(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.ProductDelete(id))
                return StatusCode(217);

            throw new Exception();
            //var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var dto = await _manager.ProductDelete(ProductEntityId);

            //if (await _manager.ProductDelete())
            //    return StatusCode(201);
        }
    }
}