using CountriesCaptialPopulation.Data;
using CountriesCaptialPopulation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace CountriesCaptialPopulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private CountryDbContext _context;
        public CountryController(CountryDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            /*HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://countriesnow.space/api/v0.1/countries/population");
            Console.WriteLine(response);*/

            return await _context.countries.ToListAsync();
        }
        [HttpGet("code")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetbyCode(string code)
        {
            var country = await _context.countries.FindAsync(code);
            return country == null ? NotFound() : Ok(country);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Country country)
        {
            await _context.countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetbyCode), new { Code = country.Code }, country);
        }


    }
}
