using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedStarter.Business.DataContract.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedStarter.API.Controllers.Product
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IProductManager _manager;

        public ValuesController( IProductManager manager)
        {
            _manager = manager;
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _manager.GetUserNameByOwnerId(id) ;
        }




    }
}
