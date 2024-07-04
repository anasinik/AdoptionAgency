using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using AdoptionAgency.Frontend.ViewModel.AnimalViewModels.EntityViewModels;
using System.Collections.ObjectModel;

namespace AdoptionAgency.Frontend.ViewModel.MemberViewModels
{
    public class MemberPageViewModel
    {
        public ObservableCollection<PostViewModel> Posts { get; set; }
        public AdoptionRequestViewModel AdoptionRequest { get; set; }

        private List<Post> _posts {  get; set; }
        public MemberPageViewModel()
        {
            Posts = new ObservableCollection<PostViewModel>();
            AdoptionRequest = new();
            SetPosts();
        }

        private void SetPosts()
        {
            var postService = new PostService();
            _posts = postService.GetAccepted();
            _posts = _posts.OrderByDescending(post => post.DatePublished).ToList();
            foreach (var post in _posts)
            {
                Posts.Add(new(post));
            }
        }

    }
}
