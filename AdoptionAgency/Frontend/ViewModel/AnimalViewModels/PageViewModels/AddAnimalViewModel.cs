using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Services.AnimalServices;
using AdoptionAgency.Frontend.ViewModel.AnimalViewModels.EntityViewModels;
using System.Windows.Forms;

namespace AdoptionAgency.Frontend.ViewModel.AnimalViewModels.PageViewModels
{
    public class AddAnimalViewModel
    {
        public AnimalViewModel Animal { get; set; }
        public AnimalSpeciesViewModel AnimalSpecies { get; set; }

        public AddAnimalViewModel()
        {
            Animal = new();
            AnimalSpecies = new();
        }

        public void AddAnimalSpecies()
        {
            var speciesService = new AnimalSpeciesService();
            Animal.Species = speciesService.Add(AnimalSpecies.ToAnimalSpecies());
            ShowSuccess("Animal species successfully added!");
        }

        public Animal AddAnimal()
        {
            var animalService = new AnimalService();
            var animal = animalService.Add(Animal.ToAnimal());
            ShowSuccess("Animal species successfully added!");
            return animal;
        }

        private void ShowSuccess(string text)
        {
            MessageBox.Show(text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
