using AdoptionAgency.Backend.Domain.Model.Animal;
using AdoptionAgency.Frontend.View.Common;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.PageViewModels;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.Post
{
    public partial class AddPost : UserControl
    {
        public AddPostViewModel AddPostViewModel { get; set; }
        private Post _parentWindow;

        public AddPost(Post parentWindow, Animal animal)
        {
            InitializeComponent();
            AddPostViewModel = new();
            DataContext = AddPostViewModel;
            AddPostViewModel.Post.Animal = animal;
            _parentWindow = parentWindow;
            pictureGrid.Children.Add(new ImageDisplay(AddPostViewModel.Post.Pictures));
        }

        private void AttachPicture_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddPostViewModel.AttachPicture();
            pictureGrid.Children.Clear();
            pictureGrid.Children.Add(new ImageDisplay(AddPostViewModel.Post.Pictures));
        }

        private void PublishPost_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AddPostViewModel.PublishPost())
                _parentWindow.Close();
        }

    }
}
