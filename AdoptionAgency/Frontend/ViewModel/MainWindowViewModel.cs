using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.View.Post;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using System.Collections.ObjectModel;
using Post = AdoptionAgency.Backend.Domain.Model.Post.Post;

namespace AdoptionAgency.Frontend.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<PostViewModel> Posts { get; set; }
        private List<Post> posts;

        public MainWindowViewModel(List<Post> posts)
        {
            this.posts = posts;
            Posts = new();
            Update();
        }

        private void Update()
        {
            var postService = new PostService();
            posts = postService.GetAccepted();
            posts = posts.OrderByDescending(post => post.DatePublished).ToList();
            Posts.Clear();
            foreach (var post in posts)
                Posts.Add(new(post));

        }
    }
}
