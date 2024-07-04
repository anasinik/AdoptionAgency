using AdoptionAgency.Backend.Services.AnimalServices;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.ViewModel;
using System.Windows;

namespace AdoptionAgency
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            var postService = new PostService();
            var animalService = new AnimalService();
            animalService.GetAll();
            ViewModel = new(postService.GetAccepted());
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}