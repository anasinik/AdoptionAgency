using AdoptionAgency.Backend.Domain.Model.Common;
using System.Reflection.Metadata;

namespace AdoptionAgency.Domain.Model.Person.Member
{
    public class MemberRating
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }

        public MemberRating(int id, int rate, string description)
        {
            Id = id;
            if (rate < Constants.MIN_RATE || rate > Constants.MAX_RATE) 
                throw new ArgumentException($"Rating must be between {Constants.MIN_RATE} and {Constants.MAX_RATE}.");
            Rate = rate;
            Description = description;
        }

    }
}
