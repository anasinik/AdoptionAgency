using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Frontend.ViewModel;

namespace AdoptionAgency.Backend.ViewModel.AnimalViewModels
{
    public class AnimalViewModel : ViewModelBase
    {
        public AnimalViewModel() { }

        public int Id { get; set; }

        private AnimalSpecies species;
        private DateTime birthDate;
        private string foundLocation;
        private Place foundPlace;
        private string healthCondition;
        private string behaviour;
        private Gender gender;
        public bool Adopted {  get; set; }
        private double weight;
        private string size;

        public AnimalSpecies Species
        {
            get { return species; }
            set
            {
                if (value != species)
                {
                    species = value;
                    OnPropertyChanged(nameof(Species));
                }
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value != birthDate)
                {
                    birthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        public string FoundLocation
        {
            get { return foundLocation; }
            set
            {
                if (value != foundLocation)
                {
                    foundLocation = value;
                    OnPropertyChanged(nameof(FoundLocation));
                }
            }
        }

        public Place FoundPlace
        {
            get { return foundPlace; }
            set
            {
                if (value != foundPlace)
                {
                    foundPlace = value;
                    OnPropertyChanged(nameof(FoundPlace));
                }
            }
        }

        public string HealthCondition
        {
            get { return healthCondition; }
            set
            {
                if (value != healthCondition)
                {
                    healthCondition = value;
                    OnPropertyChanged(nameof(healthCondition));
                }
            }
        }

        public string Behaviour
        {
            get { return behaviour; }
            set
            {
                if (value != behaviour)
                {
                    behaviour = value;
                    OnPropertyChanged(nameof(Behaviour));
                }
            }
        }

        public Gender Gender
        {
            get { return gender; }
            set
            {
                if (value != gender)
                {
                    gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value != weight)
                {
                    weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }

        public string Size
        {
            get { return size; }
            set
            {
                if (value != size)
                {
                    size = value;
                    OnPropertyChanged("Size");
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Species" && Species == null) return "Species is required";

                if (columnName == "BirthDate")
                {
                    if (birthDate > DateTime.Now) return "Please enter a valid date. Dates in the future are not allowed.";
                    if (birthDate == default) return "Birth date is required";
                }

                if (columnName == "FoundLocation")
                {
                    if (string.IsNullOrEmpty(FoundLocation)) return "Found location is required";
                }

                if (columnName == "FoundPlace" && FoundPlace == null) return "Found place is required";

                if (columnName == "HealthCondition")
                {
                    if (string.IsNullOrEmpty(HealthCondition)) return "Health condition is required";
                }

                if (columnName == "Behaviour")
                {
                    if (string.IsNullOrEmpty(Behaviour)) return "Behaviour is required";
                }

                if (columnName == "Gender" && Gender == null) return "Gender is required";

                if (columnName == "Weight")
                {
                    if (weight <= 0) return "Weight must be a positive number.";
                }

                if (columnName == "Size")
                {
                    if (string.IsNullOrEmpty(Size)) return "Size is required";
                }

                return "";
            }
        }

        private readonly string[] _validatedProperties = { "Species", "BirthDate", "FoundLocation", "FoundPlace", "HealthCondition", "Behaviour", "Gender", "Weight", "Size" };

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

        public Animal ToAnimal()
        {
            return new Animal(Id, species, birthDate, foundLocation, foundPlace, healthCondition, behaviour, gender, weight, size);
        }

        public AnimalViewModel(Animal animal)
        {
            Id = animal.Id;
            species = animal.Species;
            birthDate = animal.BirthDate;
            foundLocation = animal.FoundLocation;
            foundPlace = animal.FoundPlace;
            healthCondition = animal.HealthCondition;
            behaviour = animal.Behaviour;
            gender = animal.Gender;
            weight = animal.Weight;
            size = animal.Size;
            Adopted = animal.Adopted;
        }

    }
}
