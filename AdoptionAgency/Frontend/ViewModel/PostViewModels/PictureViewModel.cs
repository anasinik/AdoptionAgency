using AdoptionAgency.Backend.Domain.Model.Post;

namespace AdoptionAgency.Frontend.ViewModel.PostViewModels
{
    public class PictureViewModel : ViewModelBase
    {
        public int Id {  get; set; }
        public string Path { get; set; }

        public PictureViewModel(Picture picture)
        {
            Id = picture.Id;
            Path = picture.Path;
        }
        
        public Picture ToPicture()
        {
            return new Picture(Id, Path);
        }
    }
}
