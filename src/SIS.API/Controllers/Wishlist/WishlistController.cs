using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStarter.API.DataContract.Wishlist;
using RedStarter.Business.DataContract.Product;
using RedStarter.Business.DataContract.Wishlist;
using RedStarter.Business.WIshlist;

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
        public async Task<IActionResult> PostWishlist([FromBody]WishlistCreateRequest request)
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

            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); //this gets ownerId
            var dto = await _manager.GetWishlistItems(id); //executes the method
            var response = _mapper.Map<IEnumerable<WishlistResponse>>(dto); //Enumerate the items in WishlistResponse. Send it to Biz layer as a dto

            return Ok(response); //if everything's good, return the response 
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

        [HttpGet("/owner")]
        public int GetOwner()
        {
            var ownerId = User.Identity.GetUserId();
            return int.Parse(ownerId);

        }
    }
}