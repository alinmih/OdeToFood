using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        // GET: api/Restaurants
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetCuisines()
        {
            return Enum.GetNames(typeof(CuisineType)).ToList();
        }
    }
}