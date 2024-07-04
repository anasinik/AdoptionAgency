using System.Windows;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Frontend.ViewModel.Authentication;


namespace AdoptionAgency.Frontend.View.Authentication
{
    public partial class RegisterView : Window
    {
        public RegisterViewModel ViewModel{ get; set; }
        private MainWindow MainWindow { get; set; }
        public RegisterView(MainWindow mainWindow)
        {
            InitializeComponent();
            ViewModel = new RegisterViewModel();
            DataContext = ViewModel;
            gendercb.ItemsSource = Enum.GetValues(typeof(Gender));
            MainWindow = mainWindow;
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SignUp())
            {
                Close();
            }
        }
    }
}
