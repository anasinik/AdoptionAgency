using AdoptionAgency.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class Post
    {
        public int Id { get; set; }
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public Animal.Animal Animal { get; set; } = default!;
        public Member Member { get; set; } = default!;
        public Status Status { get; set; } = default!;
        public Post(){}
        public Post(int id, List<Picture> pictures, Animal.Animal animal, Member member, Status status)
        {
            Id = id;
            Pictures = pictures;
            Animal = animal;
            Member = member;
            Status = status;
        }
    }
}
