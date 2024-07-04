using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Frontend.View.Common;
using AdoptionAgency.Frontend.ViewModel;

namespace AdoptionAgency.Frontend.ViewModel.PostViewModels.EntityViewModels
{
    public class PostViewModel : ViewModelBase
    {
        public PostViewModel() { }

        public int Id { get; set; }
        public List<Picture> Pictures { get; set; } = new List<Picture>();
        public ImageDisplay ImageDisplays { get; set; }
        public Animal Animal { get; set; }
        public Person Person { get; set; }
        public Status Status { get; set; }
        public string IconPath { get; set; }

        public string Author { get; set; }

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
            return new Post(Id, Pictures, Animal, Person, Status, Description);
        }

        public PostViewModel(Post post)
        {
            Id = post.Id;
            Pictures = post.Pictures;
            Animal = post.Animal;
            Person = post.Person;
            Status = post.Status;
            Description = post.Description;
            ImageDisplays = new(post.Pictures);
            if (!post.Animal.Adopted)
                IconPath = "/Frontend/Assets/Icons/homeless.png";
            else IconPath = "/Frontend/Assets/Icons/adopted.png";
            Author = $"{post.Person.Name} {post.Person.LastName}";

        }
    }
}
