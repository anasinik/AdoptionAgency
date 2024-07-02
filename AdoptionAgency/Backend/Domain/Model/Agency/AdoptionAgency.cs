using AdoptionAgency.Backend.Domain.Model.Common;

namespace AdoptionAgency.Domain.Model.Agency
{
    public class AdoptionAgency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly FoundingDate { get; set; }
        public string Email { get;set; }
        public string Address { get; set; }
        public Place Place { get; set; }

        public AdoptionAgency(int id, string name, DateOnly foundingDate, string email, string address, Place place) {
            Id = id;
            Name = name;
            FoundingDate = foundingDate;
            Email = email;
            Address = address;
            Place = place;
        }

    }
}
