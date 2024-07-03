using AdoptionAgency.Backend.Domain.Model.Post;
using AdoptionAgency.Frontend.View.Common;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.Post
{
    public partial class AddPost : UserControl
    {
        public AddPost()
        {
            InitializeComponent();
            pictureGrid.Children.Add(new ImageDisplay(new List<Picture>()));
        }
    }
}
