
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Domain.Model.Person;

namespace AdoptionAgency.Backend.Domain.Model.Animal
{
    public class AdoptionRequest
    {
        public int Id { get; set; }
        public Person Adopter {  get; set; }
        public Animal Animal { get; set; }
        public DateTime SentAt {  get; set; }
        public DateTime ReceivedAt {  get; set; }
        public Status Status { get; set; }
        public DateTime FosterUntil {  get; set; }  // If it's a permanent adoption, this date is null

        public AdoptionRequest(int id, Person adopter, Animal animal, DateTime sentAt, DateTime receivedAt, Status status, DateTime fosterUntil)
        {
            Id = id;
            Adopter = adopter;
            Animal = animal;
            SentAt = sentAt;
            ReceivedAt = receivedAt;
            Status = status;
            FosterUntil = fosterUntil;
        }
    }
}
