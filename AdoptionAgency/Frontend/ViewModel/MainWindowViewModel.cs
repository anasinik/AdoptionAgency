using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.ViewModel.PostViewModels;
using System.Collections.ObjectModel;

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
            Posts.Clear();
            foreach (var post in posts)
                Posts.Add(new(post));
        }
    }
}
