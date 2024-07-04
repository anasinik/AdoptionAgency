using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Services.AnimalServices;
using System.Windows;

namespace AdoptionAgency.Frontend.View.UserViews
{
    public partial class AdoptionConfirmation : Window
    {
        private AdoptionRequest _request;
        public AdoptionConfirmation(AdoptionRequest request)
        {
            InitializeComponent();
            _request = request;
            HideComponents();
            confrimBtn.IsEnabled = false;
        }

        private void No_Checked(object sender, RoutedEventArgs e)
        {
            ShowComponents();
            confrimBtn.IsEnabled = false;
        }

        private void DateChanged(object sender, RoutedEventArgs e)
        {
            if (GetSelectedDate() > DateTime.Now) confrimBtn.IsEnabled = true;
        }

        private DateTime? GetSelectedDate()
        {
            return datePicker.SelectedDate ?? default;
        }

        private void Yes_Checked(object sender, RoutedEventArgs e)
        {
            HideComponents();
            confrimBtn.IsEnabled = true;
        }

        private void ShowComponents()
        {
            howLongTB.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Visible;
        }

        private void HideComponents()
        {
            howLongTB.Visibility = Visibility.Hidden;
            datePicker.Visibility = Visibility.Hidden;
        }

        private void confrimBtn_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.Visibility == Visibility.Visible)
                _request.FosterUntil = (DateTime?)GetSelectedDate();
            else
                _request.FosterUntil = null;

            var requestService = new AdoptionRequestService();
            requestService.Add(_request);
            MessageBox.Show("Success!");
            this.Close();
        }
    }
}
