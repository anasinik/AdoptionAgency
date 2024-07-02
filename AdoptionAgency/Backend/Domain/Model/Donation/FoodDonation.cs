
namespace AdoptionAgency.Backend.Domain.Model.Donation
{
    public class FoodDonation
    {
        public int Id { get; set; }
        public double Quantity {  get; set; }
        public string DonorName {  get; set; }
        public FoodDonation(int id, double quantity, string donorName)
        {
            Id = id;
            Quantity = quantity;
            DonorName = donorName;
        }
    }
}
