using AdoptionAgency.Backend.Services.AnimalServices;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using AdoptionAgency.Frontend.ViewModel.VolunteerViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.UserViews
{
    /// <summary>
    /// Interaction logic for VolunteerPostRequestsView.xaml
    /// </summary>
    public partial class VolunteerPostRequestsView : Window
    {
        public VolunteerPostRequestsViewModel ViewModel { get; set; }
        public VolunteerPostRequestsView()
        {
            InitializeComponent();
            ViewModel = new();
            DataContext = ViewModel;
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            Button adoptButton = sender as Button;
            var post = adoptButton.DataContext as PostViewModel;

            var postService = new PostService();

            if (post == null) return;
            post.Status = Backend.Domain.Model.Common.Status.Accepted;
            postsListBox.SelectedItem = post;
            postService.Update(post.ToPost());
            ViewModel.SetPosts();
        }

        private void RejectBtn_Click(object sender, RoutedEventArgs e)
        {
            Button adoptButton = sender as Button;
            var post = adoptButton.DataContext as PostViewModel;

            var postService = new PostService();

            if (post == null) return;
            post.Status = Backend.Domain.Model.Common.Status.Rejected;
            postsListBox.SelectedItem = post;
            postService.Update(post.ToPost());
            ViewModel.SetPosts();
        }
    }
}
