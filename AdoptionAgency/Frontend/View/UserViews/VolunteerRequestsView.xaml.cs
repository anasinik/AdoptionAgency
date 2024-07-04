using AdoptionAgency.Backend.Domain.Model.Common;
using AdoptionAgency.Backend.Services;
using AdoptionAgency.Frontend.ViewModel.VolunteerViewModel;
using System.Windows;

namespace AdoptionAgency.Frontend.View.UserViews
{
    public partial class VolunteerRequestsView : Window
    {
        public VolunteerRequestsViewModel ViewModel { get; set; }
        public VolunteerRequestsView()
        {
            InitializeComponent();
            ViewModel = new VolunteerRequestsViewModel();
            DataContext = ViewModel;
        }
        private void AcceptReqBtn_Click(object sender, RoutedEventArgs e)
        {
            var member = ViewModel.SelectedMember;
            member.User.Status = Status.Accepted;
            var personService = new PersonService();
            personService.Update(member.ToMember());
            var members = ViewModel.Members;
            members.Remove(member);
        }
        private void RejectReqBtn_Click(object sender, RoutedEventArgs e)
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
