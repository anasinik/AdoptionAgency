using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using AdoptionAgency.Frontend.ViewModel.VolunteerViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.UserViews
{
    public partial class VolunteerPostRequestsView : Window
    {
        public VolunteerPostRequestsViewModel ViewModel { get; set; }
        public VolunteerPostRequestsView()
        {
            InitializeComponent();
            ViewModel = new();
            DataContext = ViewModel;
            Closing += Request_Closing;
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

       
    private void Request_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var window = new VolunteerView();
        window.Show();
    }
}
}
