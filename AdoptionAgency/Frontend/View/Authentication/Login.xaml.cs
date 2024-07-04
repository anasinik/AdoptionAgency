using AdoptionAgency.Backend.Services.AuthentificationService;
using AdoptionAgency.Frontend.ViewModel;
using AdoptionAgency.Frontend.ViewModel.Authentication;
using System.Windows;

namespace AdoptionAgency.Frontend.View.Authentication
{
    public partial class Login : Window
    {
        public LoginViewModel ViewModel { get; set; }
        public Login()
        {
            ViewModel = new();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var loginService = new LoginService();
            App.LoggedPerson = loginService
                .GetByCredentials(ViewModel.UserName, ViewModel.Password);
            if (ViewModel.Login()) Close();
        }
    }
}
