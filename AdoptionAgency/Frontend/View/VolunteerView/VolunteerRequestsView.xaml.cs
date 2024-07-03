using AdoptionAgency.Backend.Domain.Model.Person;
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
            var personService = new PersonService();
            //TODO Check if there is need for new User object
            personService.Add(new Volunteer(member.Id, member.User, member.Name,
                member.LastName, member.Email, member.PhoneNumber));
            personService.Delete(member.Id);
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
