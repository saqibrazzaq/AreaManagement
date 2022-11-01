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

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var res = _cityService.FindById(id);
            return Ok(res);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create(CityReqEdit dto)
        {
            var res = _cityService.Create(dto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(int id, CityReqEdit dto)
        {
            var res = _cityService.Update(id, dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cityService.Delete(id);
            return NoContent();
        }
    }
}
