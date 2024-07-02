namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class Reaction
    {
        public int Id { get; set; }
        public ReactionType Type { get; set; }
        public Person.Person Person { get; set; } = default!;
        public Reaction(){}
        public Reaction(int id, ReactionType type, Person.Person person)
        {
            Id = id;
            Type = type;
            Person = person;
        }
    }
}
