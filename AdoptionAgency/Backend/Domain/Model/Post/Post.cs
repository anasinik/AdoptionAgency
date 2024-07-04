using AdoptionAgency.Backend.Domain.Model.Common;
namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class Post
    {
        public int Id { get; set; }
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public Animal.Animal Animal { get; set; } = default!;
        public int AnimalId { get; set; }
        public Person.Person Person { get; set; } = default!;
        public int PersonId { get; set; }
        public Status Status { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Post(){}
        public Post(int id, List<Picture> pictures, Animal.Animal animal,Person.Person person, Status status, string description)
        {
            Id = id;
            Pictures = pictures;
            Animal = animal;
            Person = person;
            Status = status;
            Description = description;
        }
    }
}
