using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CountriesCaptialPopulation.Model
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public List<PopulationList> Populations { get; set; }

    }
    public class PopulationList
    {   
        public int ID { get; set; }
        public int year { get; set; }
        public int value { get; set; }
        public string Code { get; set; }
        public Country country { get; set; }
    }
}
