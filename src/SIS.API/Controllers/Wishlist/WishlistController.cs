using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Wishlist;
using RedStarter.Business.DataContract.Product;
using RedStarter.Business.DataContract.Wishlist;

namespace RedStarter.API.Controllers.Wishlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWishlistManager _manager;

        public WishlistController(IMapper mapper, IWishlistManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> PostWishlist(WishlistCreateRequest request)
        {

            if (!ModelState.IsValid) //want this to check 
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = _mapper.Map<WishlistCreateDTO>(request);
            //dto.ProductId = WHAT GOIES HERE?!?!
            dto.OwnerId = identityClaimNum;

            if (await _manager.CreateWishlist(dto))
                return StatusCode(201);

            throw new Exception();
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        public async Task<IActionResult> GetWishlistItems()
        {
            if (!ModelState.IsValid) //want this to check 
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = await _manager.GetWishlistItems();
            var response = _mapper.Map<IEnumerable<WishlistResponse>>(dto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishlistById(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = await _manager.GetWishlistById(id);
            var response = _mapper.Map<WishlistResponse>(dto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> WishlistEdit(int id, WishlistEditRequest request)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            var identityClaimNum = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var dto = _mapper.Map<WishlistEditDTO>(request);

            if (await _manager.WishlistEdit(dto))
                return StatusCode(202);

            throw new Exception();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> WishlistDelete(int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            if (await _manager.WishlistDelete(id))
                return StatusCode(217);

            throw new Exception();
        }
    }
}