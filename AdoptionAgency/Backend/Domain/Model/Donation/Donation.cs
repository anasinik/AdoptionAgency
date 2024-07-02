
namespace AdoptionAgency.Backend.Domain.Model.Donation
{
    public class Donation
    {
        public int Id { get; set; }
        public string From { get; set; }  // bank account  
        public double Amount { get; set; }
        public DonationType Type { get; set; }
        public string DonorName {  get; set; }
        public Animal.Animal Animal { get; set; }

        public Donation(int id, string from, double amount, DonationType type, Animal.Animal animal)
        {
            Id = id;
            From = from;
            Amount = amount;
            Type = type;
            Animal = animal;
        }
    }
}
