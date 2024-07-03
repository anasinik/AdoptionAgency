using System.Windows;

namespace AdoptionAgency.Frontend.View.Post
{
    public partial class Post : Window
    {
        public Post()
        {
            InitializeComponent();
            contentGrid.Children.Add(new AddAnimal(this));
        }
    }
}
