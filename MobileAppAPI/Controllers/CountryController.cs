using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAppAPI.Data;
using MobileAppAPI.Interfaces;
using MobileAppAPI.Models;

namespace MobileAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly DataContext _context;
        public CountryController(ICountryRepository countryRepository, DataContext context)
        {
            _countryRepository = countryRepository;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var country = _countryRepository.GetCountries();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }
    }
}
