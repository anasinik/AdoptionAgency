
namespace AdoptionAgency.Backend.Domain.Model.Donation
{
    public class DonationUsage
    {
        public int Id { get; set; }
        public double Amount {  get; set; }
        public DateTime UsageDate {  get; set; }

        public DonationUsage(int id, double amount, DateTime usageDate)
        {
            Id = id;
            Amount = amount;
            UsageDate = usageDate;
        }
    }
}
