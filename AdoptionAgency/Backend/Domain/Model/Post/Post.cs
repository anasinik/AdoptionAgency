using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class Post
    {
        public int Id { get; set; }
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public Animal.Animal Animal { get; set; } = default!;
        public Member Member { get; set; } = default!;
        public Status Status { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Post(){}
        public Post(int id, List<Picture> pictures, Animal.Animal animal, Member member, Status status, string description)
        {
            Id = id;
            Pictures = pictures;
            Animal = animal;
            Member = member;
            Status = status;
            Description = description;
        }
    }
}
