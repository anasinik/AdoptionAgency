using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Frontend.ViewModel;

namespace AdoptionAgency.Backend.ViewModel.AnimalViewModels
{
    public class AnimalSpeciesViewModel : ViewModelBase
    {
        public AnimalSpeciesViewModel() { }

        public int Id { get; set; }

        private string species;
        private string breed;

        public string Species
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

        public string Breed
        {
            get { return breed; }
            set
            {
                if (value != breed)
                {
                    breed = value;
                    OnPropertyChanged(nameof(Breed));
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Species")
                {
                    if (string.IsNullOrEmpty(Species)) return "Species is required";
                }

                if (columnName == "Breed")
                {
                    if (string.IsNullOrEmpty(Breed)) return "Breed is required";
                }

                return "";
            }
        }

        private readonly string[] _validatedProperties = { "Species", "Breed" };

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

        public AnimalSpecies ToAnimalSpecies()
        {
            return new AnimalSpecies(Id, species, breed);
        }

        public AnimalSpeciesViewModel(AnimalSpecies animalSpecies)
        {
            Id = animalSpecies.Id;
            species = animalSpecies.Species;
            breed = animalSpecies.Breed;
        }
    }
}
