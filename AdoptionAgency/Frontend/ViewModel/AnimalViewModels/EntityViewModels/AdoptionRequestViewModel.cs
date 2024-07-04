using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Person;

namespace AdoptionAgency.Frontend.ViewModel.AnimalViewModels.EntityViewModels
{
    public class AdoptionRequestViewModel : ViewModelBase
    {
        public AdoptionRequestViewModel() { }

        public int Id { get; set; }

        private Person adopter;
        private Animal animal;
        private DateTime sentAt;
        private DateTime receivedAt;
        private Status status;
        private DateTime fosterUntil;

        public Person Adopter
        {
            get { return adopter; }
            set
            {
                if (value != adopter)
                {
                    adopter = value;
                    OnPropertyChanged(nameof(Adopter));
                }
            }
        }

        public Animal Animal
        {
            get { return animal; }
            set
            {
                if (value != animal)
                {
                    animal = value;
                    OnPropertyChanged(nameof(Animal));
                }
            }
        }

        public DateTime SentAt
        {
            get { return sentAt; }
            set
            {
                if (value != sentAt)
                {
                    sentAt = value;
                    OnPropertyChanged(nameof(SentAt));
                }
            }
        }

        public DateTime ReceivedAt
        {
            get { return receivedAt; }
            set
            {
                if (value != receivedAt)
                {
                    receivedAt = value;
                    OnPropertyChanged(nameof(ReceivedAt));
                }
            }
        }

        public Status Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public DateTime FosterUntil
        {
            get { return fosterUntil; }
            set
            {
                if (value != fosterUntil)
                {
                    fosterUntil = value;
                    OnPropertyChanged(nameof(FosterUntil));
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Adopter" && Adopter == null) return "Adopter is required";

                if (columnName == "Animal" && Animal == null) return "Animal is required";

                if (columnName == "SentAt")
                {
                    if (sentAt > DateTime.Now) return "Please enter a valid date. Dates in the future are not allowed.";
                    if (sentAt == default) return "Sent date is required";
                }

                if (columnName == "ReceivedAt")
                {
                    if (receivedAt > DateTime.Now) return "Please enter a valid date. Dates in the future are not allowed.";
                    if (receivedAt == default) return "Received date is required";
                }

                if (columnName == "Status" && Status == null) return "Status is required";

                if (columnName == "FosterUntil")
                {
                    if (fosterUntil > DateTime.Now) return "Please enter a valid date. Dates in the future are not allowed.";
                }

                return "";
            }
        }

        private readonly string[] _validatedProperties = { "Adopter", "Animal", "SentAt", "ReceivedAt", "Status", "FosterUntil" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != "")
                        return false;
                }
                return true;
            }
        }

        public AdoptionRequest ToAdoptionRequest()
        {
            return new AdoptionRequest(Id, Adopter, Animal, sentAt, receivedAt, Status, fosterUntil);
        }

        public AdoptionRequestViewModel(AdoptionRequest adoptionRequest)
        {
            Id = adoptionRequest.Id;
            Adopter = adoptionRequest.Adopter;
            Animal = adoptionRequest.Animal;
            SentAt = adoptionRequest.SentAt;
            ReceivedAt = adoptionRequest.ReceivedAt;
            Status = adoptionRequest.Status;
            FosterUntil = adoptionRequest.FosterUntil;
        }
    }
}
