using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Services.AnimalServices;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using AdoptionAgency.Frontend.ViewModel.VolunteerViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.UserViews
{
    public partial class VolunteerView : Window
    {
        public VolunteerPageViewModel ViewModel { get; set; }
        public VolunteerView()
        {
            InitializeComponent();
            ViewModel = new VolunteerPageViewModel();
            DataContext = ViewModel;
        }

        private void AdoptBtn_Click(object sender, RoutedEventArgs e)
        {
            Button adoptButton = sender as Button;
            var post = adoptButton.DataContext as PostViewModel;

            var requestService = new AdoptionRequestService();

            if (post == null) return;
            postsListBox.SelectedItem = post;

            if (post.Animal.Adopted)
                ShowInfo("Animal is already adopted, please select another.");

            else if (requestService.Exists(post.Animal, post.Person))
                ShowInfo("Adoption request has already been sent.");

            else
                AskUserForPermanentAdoption(post);
        }

        private void AskUserForPermanentAdoption(PostViewModel post)
        {
            AdoptionRequest request = new()
            {
                Adopter = post.Person, // TODO: when loggedIn is saved
                Animal = post.Animal,
                SentAt = DateTime.Now,
                ReceivedAt = DateTime.Now,
                Status = Status.Pending,
                FosterUntil = DateTime.Now
            };
            AdoptionConfirmation confirmation = new(request);
            confirmation.Show();
        }

        private void ShowInfo(string text)
        {
            MessageBox.Show(text, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddPostBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new Post.Post();
            window.Show();
            Close();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ViewRegReqBtn_Click(object sender, RoutedEventArgs e)
        {
            VolunteerRequestsView window = new();
            window.Show();
        }

        private void viewPostReqBtn_Click(object sender, RoutedEventArgs e)
        {
            VolunteerPostRequestsView window = new();
            window.Show();
            Close();
        }
    }
}
