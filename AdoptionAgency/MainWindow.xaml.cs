using AdoptionAgency.Backend.Services.AnimalServices;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.View.Authentication;
using AdoptionAgency.Frontend.ViewModel;
using System.Windows;

namespace AdoptionAgency
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            var postService = new PostService();
            var animalService = new AnimalService();
            animalService.GetAll();
            ViewModel = new(postService.GetAccepted());
            DataContext = ViewModel;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new Login(this);
            window.Show();
        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegisterView();
            window.Show();
        }
    }
}