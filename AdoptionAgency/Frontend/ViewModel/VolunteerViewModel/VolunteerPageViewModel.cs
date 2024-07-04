using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.ViewModel.AnimalViewModels.EntityViewModels;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using System.Collections.ObjectModel;

namespace AdoptionAgency.Frontend.ViewModel.VolunteerViewModel
{
    public class VolunteerPageViewModel
    {
        public ObservableCollection<PostViewModel> Posts { get; set; }
        public AdoptionRequestViewModel AdoptionRequest { get; set; }

        private List<Post> _posts { get; set; }

        public VolunteerPageViewModel()
        {
            Posts = new ObservableCollection<PostViewModel>();
            AdoptionRequest = new();
            var postService = new PostService();
            _posts = postService.GetAccepted();
            SetPosts();
        }

        private void SetPosts()
        {
            foreach (var post in _posts)
            {
                Posts.Add(new(post));
            }
        }

    }
}
