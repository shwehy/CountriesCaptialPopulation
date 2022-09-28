using CountriesCaptialPopulation.Model;
using Microsoft.EntityFrameworkCore;
using System;


namespace CountriesCaptialPopulation.Data
{
    public class CountryDbContext:DbContext
    {
        public CountryDbContext(DbContextOptions<CountryDbContext> options) : base(options)
        {

        }

        public DbSet<Country> countries { get; set; }
        public DbSet<PopulationList> populationLists { get; set; }
    }
}
