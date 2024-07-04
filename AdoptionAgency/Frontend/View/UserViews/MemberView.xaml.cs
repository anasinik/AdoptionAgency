using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Services.AnimalServices;
using AdoptionAgency.Backend.ViewModel.PostViewModels;
using AdoptionAgency.Frontend.ViewModel.MemberViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.UserViews
{
    public partial class MemberView : Window
    {
        public MemberPageViewModel viewModel {  get; set; }
        public MemberView()
        {
            InitializeComponent();
            viewModel = new();
            DataContext = viewModel;
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

    }
}
