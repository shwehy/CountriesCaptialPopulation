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
            return await _context.countries.ToListAsync();
        }
    }
}
