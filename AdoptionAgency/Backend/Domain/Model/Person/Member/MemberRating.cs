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
            Rate = rate;
            Description = description;
        }

    }
}
