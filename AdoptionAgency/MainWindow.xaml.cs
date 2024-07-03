using AdoptionAgency.Frontend.ViewModel;
using System.Windows;

namespace AdoptionAgency
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {
            ViewModel = new();
            DataContext = ViewModel;
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Login()) Close();
        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ShowRegistrationWindow();
            Close();
        }
    }
}