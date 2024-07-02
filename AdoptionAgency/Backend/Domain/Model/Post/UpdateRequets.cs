
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Domain.Model.Person.Member;

namespace AdoptionAgency.Backend.Domain.Model.Post
{
    public class UpdateRequets
    {
        public int Id { get; set; }
        public Post Post { get; set; } = default!;
        public Member Member { get; set; } = default!;
        public Status Status { get; set; } = default!;
        public UpdateRequets(){}
        public UpdateRequets(int id, Post post, Member member, Status status)
        {
            Id = id;
            Post = post;
            Member = member;
            Status = status;
        }
    }
}
