using api.ActionFilters;
using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Default()
        {
            var res = _countryService.SearchCountries(new CountryReqSearch());
            return Ok(res);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] CountryReqSearch dto)
        {
            var res = _countryService.SearchCountries(dto);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var res = _countryService.FindById(id);
            return Ok(res);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create(CountryReqEdit dto)
        {
            var res = _countryService.Create(dto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(int id, CountryReqEdit dto)
        {
            var res = _countryService.Update(id, dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _countryService.Delete(id);
            return NoContent();
        }
    }
}
