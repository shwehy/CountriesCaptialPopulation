using CountriesCaptialPopulation.Data;
using CountriesCaptialPopulation.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CountriesCaptialPopulation.Controllers
{
    public class getData
    {
        public string url = "https://countriesnow.space/api/v0.1/countries/population";
        public getData(CountryDbContext context)
        {
            _context = context;
        }
        private CountryDbContext _context;
        public async void save_Change()
        {
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<JToken>(response.Content);
            /*for (int i  = 0; i < result.Count; i++)
            {
                if (_context.Entry(result[i]).State == EntityState.Modified)
                {
                    await _context.SaveChangesAsync();
                    continue;
                }


            }*/
            Country country = new Country();
             country.Name = result["country"].ToString();


           /* var country = new Country();
            country.CountryID = 1;*/
            country.Code = result["code"].ToString(); 
            var pop = new PopulationList();
            pop.ID = 1;
            pop.year = int.Parse(result["year"].ToString());

            pop.country = country;
            pop.value = int.Parse(result["value"].ToString()); ;

            /*            country.Populations.Add(pop);
            */
            await _context.countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }
    }
}
