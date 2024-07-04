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

        public void AddAnimal()
        {
            var animalService = new AnimalService();
            animalService.Add(Animal.ToAnimal());
            ShowSuccess("Animal species successfully added!");
        }

        private void ShowSuccess(string text)
        {
            MessageBox.Show(text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
