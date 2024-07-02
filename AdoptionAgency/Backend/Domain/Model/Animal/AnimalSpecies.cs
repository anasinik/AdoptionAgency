
namespace AdoptionAgency.Backend.Domain.Model.Animal
{
    public class AnimalSpecies
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }

        public AnimalSpecies(int id, string species, string breed)
        {
            Id = id;
            Species = species;
            Breed = breed;
        }
    }
}
