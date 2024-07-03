using System.Windows;
using System.Windows.Controls;

namespace AdoptionAgency.Frontend.View.Post
{
    public partial class AddAnimal : UserControl
    {
        private readonly Post _parentWindow;
        public AddAnimal(Post parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.contentGrid.Children.Clear();
            _parentWindow.contentGrid.Children.Add(new AddPost());
        }

    }
}
