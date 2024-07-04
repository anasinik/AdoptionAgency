using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Frontend.ViewModel.AnimalViewModels.PageViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.Post
{
    public partial class AddAnimal : UserControl
    {
        public AddAnimalViewModel AddAnimalViewModel { get; set; }
        private readonly Post _parentWindow;
        private Animal _animal;

        public AddAnimal(Post parentWindow)
        {
            InitializeComponent();
            AddAnimalViewModel = new();
            DataContext = AddAnimalViewModel;
            _parentWindow = parentWindow;
            genderCB.ItemsSource = Enum.GetValues(typeof(Gender));
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.contentGrid.Children.Clear();
            _parentWindow.contentGrid.Children.Add(new AddPost(_parentWindow, _animal));
        }

        private void AddAnimalSpecies_Click(object sender, RoutedEventArgs e)
        {
            AddAnimalViewModel.AddAnimalSpecies();
            EnableAnimalsForm();
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            _animal = AddAnimalViewModel.AddAnimal();
            nextPageBtn.IsEnabled = true;
        }

        private void EnableAnimalsForm()
        {
            animalBehaviourTB.IsEnabled = true;
            foundLocationTB.IsEnabled = true;
            healthConditionTB.IsEnabled = true;
            sizeTB.IsEnabled = true;
            weightTB.IsEnabled = true;
            genderCB.IsEnabled = true;
            datePicker.IsEnabled = true;
            addAnimalBtn.IsEnabled = true;
        }

    }
}
