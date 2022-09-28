using CountriesCaptialPopulation.Model;
using Microsoft.EntityFrameworkCore;


namespace CountriesCaptialPopulation.Data
{
    public class CountryDbContext:DbContext
    {
        public CountryDbContext(DbContextOptions<CountryDbContext> options) : base(options)
        {

        }
        public DbSet<Country> countries { get; set; }
    }
}
