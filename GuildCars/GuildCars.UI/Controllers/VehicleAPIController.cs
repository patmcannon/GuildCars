using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class VehicleAPIController : ApiController
    {
        [Route("api/vehicles/search")]
        [HttpGet]
        [AcceptVerbs("GET")]
        [AllowAnonymous]
        public IHttpActionResult Search(string quickSearch, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, bool? isNew)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    QuickSearch = quickSearch,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    IsNew = isNew
                };
                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet]
        [AcceptVerbs("GET")]
        [AllowAnonymous]
        [Route("api/inventory/search")]
        public IHttpActionResult Test(string quickSearch, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear, bool? isNew)
        {
            return Ok(minPrice);
        }
    }
}
