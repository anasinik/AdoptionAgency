using AdoptionAgency.Frontend.ViewModel.Authentication;
using System.Windows;

namespace AdoptionAgency.Frontend.View.Authentication
{
    public partial class Login : Window
    {
        public LoginViewModel ViewModel { get; set; }
        private MainWindow MainWindow { get; set; }
        public Login(MainWindow mainWindow)
        {
            ViewModel = new(mainWindow);
            DataContext = ViewModel;
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Login())
            {
                Close();
                MainWindow.Close();
            }
        }
    }
}