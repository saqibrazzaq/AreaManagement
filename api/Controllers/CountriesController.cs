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
        private readonly IDataResetService _resetService;
        public CountriesController(ICountryService countryService, 
            IDataResetService resetService)
        {
            _countryService = countryService;
            _resetService = resetService;
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

        [HttpGet("searchWithStatesCount")]
        public IActionResult SearchWithStatesCount([FromQuery] CountryReqSearch dto)
        {
            var res = _countryService.SearchCountriesWithStatesCount(dto);
            return Ok(res);
        }

        [HttpGet("{countryId}")]
        public IActionResult FindById(int countryId)
        {
            var res = _countryService.Get(countryId);
            return Ok(res);
        }

        [HttpGet("GetCountryWithStatesCount/{countryId}")]
        public IActionResult GetCountryWithStatesCount(int countryId)
        {
            var res = _countryService.GetCountryWithStatesCount(countryId);
            return Ok(res);
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            var res = _countryService.Count();
            return Ok(res);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create(CountryReqEdit dto)
        {
            var res = _countryService.Create(dto);
            return Ok(res);
        }

        [HttpPut("{countryId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(int countryId, CountryReqEdit dto)
        {
            var res = _countryService.Update(countryId, dto);
            return Ok(res);
        }

        [HttpDelete("{countryId}")]
        public IActionResult Delete(int countryId)
        {
            _countryService.Delete(countryId);
            return NoContent();
        }

        [HttpPost("reset")]
        public IActionResult Reset()
        {
            _resetService.ResetAllData();
            return NoContent();
        }
    }
}
