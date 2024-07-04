using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Services.PostServices;
using AdoptionAgency.Frontend.ViewModel.AnimalViewModels.EntityViewModels;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptionAgency.Frontend.ViewModel.VolunteerViewModel
{
    public class VolunteerPostRequestsViewModel : ViewModelBase
    {
        public ObservableCollection<PostViewModel> Posts { get; set; }

        private List<Post> _posts { get; set; }
        public VolunteerPostRequestsViewModel()
        {
            Posts = new ObservableCollection<PostViewModel>();
            SetPosts();
        }

        public void SetPosts()
        {
            var postService = new PostService();
            var temp = postService.GetAll();
            Posts.Clear();
            _posts = postService.GetAllPending();
            foreach (var post in _posts)
            {
                Posts.Add(new(post));
            }
        }
    }
}
