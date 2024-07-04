using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services.AuthentificationService;
using AdoptionAgency.Backend.ViewModel.PostViewModels;
using AdoptionAgency.Frontend.View.AdminView;
using AdoptionAgency.Frontend.View.Authentication;
using AdoptionAgency.Frontend.View.Member;
using AdoptionAgency.Frontend.View.VolunteerView;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Authentication;

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
