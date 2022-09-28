using CountriesCaptialPopulation.Data;
using CountriesCaptialPopulation.Model;

namespace CountriesCaptialPopulation.Controllers
{
    public class getData
    {
        public getData(CountryDbContext context)
        {
            _context = context;
        }
        private CountryDbContext _context;
        public async void save_Change()
        {
            var country = new Country();
            country.CountryID = 1;
            country.Code = "4";
            country.Name = "temp";
            var pop = new PopulationList();
            pop.ID = 1;
            pop.year = 2020;
            pop.country = country;
            pop.value = 100202;

            country.Populations.Add(pop);
            await _context.countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }
    }
}
