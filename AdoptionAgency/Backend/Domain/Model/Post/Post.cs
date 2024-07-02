using AdoptionAgency.Domain.Model.Person.Member;
namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class Post
    {
        public int Id { get; set; }
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public Animal Animal { get; set; } = default!;
        public Member Member { get; set; } = default!;
        public Post(){}
        public Post(int id, List<Picture> pictures, Animal animal, Member member)
        {
            Id = id;
            Pictures = pictures;
            Animal = animal;
            Member = member;
        }
    }
}
