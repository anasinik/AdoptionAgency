using AdoptionAgency.Frontend.View.UserViews;
using System.Windows;

namespace AdoptionAgency.Frontend.View.Post
{
    public partial class Post : Window
    {
        public Post()
        {
            InitializeComponent();
            contentGrid.Children.Add(new AddAnimal(this));
            Closing += Post_Closing;
        }

        private void Post_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var window = new VolunteerView();
            window.Show();
        }
    }
}
