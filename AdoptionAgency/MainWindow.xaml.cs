using AdoptionAgency.Backend.Services;
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
            var postService = new PostService();
            ViewModel = new(postService.GetAll());
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            Close();
        }
    }
}