using AdoptionAgency.Backend.Services;
using AdoptionAgency.Frontend.ViewModel.VolunteerViewModel;
using AdoptionAgency.Backend.Domain.Model;
using System.Windows;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Common;

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
            member.User.Status = Status.Accepted;
            var personService = new PersonService();
            personService.Update(member.ToMember());
            var members = ViewModel.Members;
            members.Remove(member);
        }
        private void RejectReqBtn(object sender, RoutedEventArgs e)
        {
            var member = ViewModel.SelectedMember;
            member.User.Status = Status.Rejected;
            var personService = new PersonService();
            personService.Update(member.ToMember());
            var members = ViewModel.Members;
            members.Remove(member);
        }
    }
}
