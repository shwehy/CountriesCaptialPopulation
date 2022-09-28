using System.ComponentModel.DataAnnotations;

namespace CountriesCaptialPopulation.Model
{
    public class Country
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public List<PopulationList> Populations { get; set; }

    }
    public class PopulationList
    {
        public int year;
        public int value;
    }
}
