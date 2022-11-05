using api.ActionFilters;
using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery]CityReqSearch dto)
        {
            var res = _cityService.SearchCities(dto);
            return Ok(res);
        }

        [HttpGet("searchCitiesWithAreasCount")]
        public IActionResult SearchCitiesWithAreasCount([FromQuery] CityReqSearch dto)
        {
            var res = _cityService.SearchCitiesWithAreaCount(dto);
            return Ok(res);
        }

        [HttpGet("{cityId}")]
        public IActionResult FindById(int cityId)
        {
            var res = _cityService.FindById(cityId);
            return Ok(res);
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            var res = _cityService.Count();
            return Ok(res);
        }
        
        [HttpGet("GetCityDetails/{cityId}")]
        public IActionResult GetCityDetails(int cityId)
        {
            var res = _cityService.GetCityDetails(cityId);
            return Ok(res);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create(CityReqEdit dto)
        {
            var res = _cityService.Create(dto);
            return Ok(res);
        }

        [HttpPut("{cityId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(int cityId, CityReqEdit dto)
        {
            var res = _cityService.Update(cityId, dto);
            return Ok(res);
        }

        [HttpDelete("{cityId}")]
        public IActionResult Delete(int cityId)
        {
            _cityService.Delete(cityId);
            return NoContent();
        }
    }
}
