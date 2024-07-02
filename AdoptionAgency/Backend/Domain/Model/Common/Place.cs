
namespace AdoptionAgency.Backend.Domain.Model.Common
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostalCode {  get; set; }

        public Place(int id, string name, int postalCode)
        {
            Id = id;
            Name = name;
            PostalCode = postalCode;
        }
    }
}
