using System.Windows;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Frontend.ViewModel.Authentication


namespace AdoptionAgency.Frontend.View.Authentication
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterMemberViewModel ViewModel{ get; set; }
        public RegisterView()
        {
            InitializeComponent();
            ViewModel = new RegisterMemberViewModel();
            DataContext = ViewModel;
            gendercb.ItemsSource = Enum.GetValues(typeof(Gender));
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SignUp()) Close();
        }
    }
}
