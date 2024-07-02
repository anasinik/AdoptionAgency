
using AdoptionAgency.Backend.Domain.Model.Common;

namespace AdoptionAgency.Backend.Domain.Model.Animal
{
    public class AnimalRating
    {
        public int Id {  get; set; }
        public AdoptionRequest Adoption {  get; set; }
        public int Rate {  get; set; }
        public string Description { get; set; }

        public AnimalRating(int id, AdoptionRequest adoption, int rate, string description)
        {
            Id = id;
            Adoption = adoption;
            if (rate < Constants.MIN_RATE || rate > Constants.MAX_RATE) throw new ArgumentException($"Rating must be between {Constants.MIN_RATE} and {Constants.MAX_RATE}.");
            Rate = rate;
            Description = description;
        }
    }
}
