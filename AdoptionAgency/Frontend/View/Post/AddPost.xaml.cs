using AdoptionAgency.Frontend.View.Common;
using AdoptionAgency.Frontend.ViewModel.PostViewModels.PageViewModels;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.Post
{
    public partial class AddPost : UserControl
    {
        public AddPostViewModel AddPostViewModel { get; set; }
        public AddPost()
        {
            InitializeComponent();
            AddPostViewModel = new();
            DataContext = AddPostViewModel;
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
                AddPostViewModel.PublishPost();
        }

    }
}
