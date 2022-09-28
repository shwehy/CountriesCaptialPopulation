using CountriesCaptialPopulation.Data;
using CountriesCaptialPopulation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CountriesCaptialPopulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private CountryDbContext _context;
        public string url = "https://countriesnow.space/api/v0.1/countries/population";
        public CountryController(CountryDbContext context)
        {
            _context = context;
        }
        [HttpGet("pageno")]
        public async Task<IEnumerable<Country>> Get(int pageno )
        {
            /*HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://countriesnow.space/api/v0.1/countries/population");
            Console.WriteLine(response);*/
            /*Console.WriteLine("get is pressed");*/
            /* var client = new RestClient(url);
             var request = new RestRequest(url, Method.Get);
             RestResponse response = await client.ExecuteAsync(request);*/
            /*var Output = response.Content;*/

            /*            getData update = new getData(_context);

                        update.save_Change();*/

            /*return await _context.countries.ToListAsync();*/
            return await _context.countries.Skip((pageno - 1) * 50).Take(50).ToListAsync();
        }
        [HttpGet("id")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetbyCode(int Id)
        {
            
            var country = await _context.countries.FindAsync(Id);
            return country == null ? NotFound() : Ok(country);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Country country)
        {

            await _context.countries.AddAsync(country);
            return CreatedAtAction(nameof(GetbyCode), new { Code = country.CountryID }, country);
        }

        


    }
}
