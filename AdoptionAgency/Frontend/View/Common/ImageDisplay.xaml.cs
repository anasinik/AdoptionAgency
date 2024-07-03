using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Frontend.ViewModel.PostViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.Common
{
    public partial class ImageDisplay : UserControl
    {
        private List<Picture> pictures;
        public ObservableCollection<PictureViewModel> Pictures { get; set; }

        public ImageDisplay(List<Picture> allPictures)
        {
            InitializeComponent();
            DataContext = this;
            pictures = allPictures;
            Pictures = new ObservableCollection<PictureViewModel>();
            Update();
        }

        public void Update()
        {
            Pictures.Clear();
            foreach (var picture in pictures)
                Pictures.Add(new(picture));
        }
    }
}
