namespace AdoptionAgency.Domain.Model.Agency
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public float Balance { get; set; }

        public BankAccount(int id, string number, float balance){
            Id = id;
            Number = number;
            Balance = balance;
        }

    }
}
