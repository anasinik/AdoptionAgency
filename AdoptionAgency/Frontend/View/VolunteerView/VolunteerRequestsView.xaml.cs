using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Services;
using AdoptionAgency.Frontend.ViewModel.VolunteerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdoptionAgency.Frontend.View.VolunteerView
{
    /// <summary>
    /// Interaction logic for VolunteerRequestsView.xaml
    /// </summary>
    public partial class VolunteerRequestsView : Window
    {
        public VolunteerRequestsViewModel ViewModel { get; set; }
        public VolunteerRequestsView()
        {
            InitializeComponent();
            ViewModel = new VolunteerRequestsViewModel();
            DataContext = ViewModel;
        }
        private void AcceptReqBtn(object sender, RoutedEventArgs e)
        {
            var member = ViewModel.SelectedMember;
            var volunteerService = new PersonService();
            var members = ViewModel.Members;
            members.Remove(member);
        }
        private void RejectReqBtn(object sender, RoutedEventArgs e)
        {
            var member = ViewModel.SelectedMember;
            var members = ViewModel.Members;
            members.Remove(member);
        }
    }
}
