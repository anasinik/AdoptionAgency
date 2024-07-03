using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Frontend.ViewModel;

namespace AdoptionAgency.Backend.ViewModel.PostViewModels
{
    public class PostViewModel : ViewModelBase
    {
        public PostViewModel() { }

        public int Id { get; set; }
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public Animal Animal { get; set; }
        public Member Member { get; set; }
        public Status Status { get; set; }
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Description")
                {
                    if (string.IsNullOrEmpty(Description)) return "Description is required";
                }
                return "";
            }
        }

        private readonly string[] _validatedProperties = { "Description" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != "")
                        return false;
                }
                return true;
            }
        }

        public Post ToPost()
        {
            return new Post(Id, Pictures, Animal, Member, Status, Description);
        }

        public PostViewModel(Post post)
        {
            Id = post.Id;
            Pictures = post.Pictures;
            Animal = post.Animal;
            Member = post.Member;
            Status = post.Status;
            Description = post.Description;
        }
    }
}
