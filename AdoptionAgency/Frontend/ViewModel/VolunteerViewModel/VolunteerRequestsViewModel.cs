using AdoptionAgency.Backend.Domain.Model.Person;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using AdoptionAgency.Backend.Services;
using AdoptionAgency.Frontend.ViewModel.MemberViewModels;
using System.Collections.ObjectModel;

namespace AdoptionAgency.Frontend.ViewModel.VolunteerViewModel
{
    public class VolunteerRequestsViewModel : ViewModelBase
    {
        public ObservableCollection<MemberViewModel> Members { get; set; }
        public MemberViewModel SelectedMember { get; set; }
        private List<Person> _members { get; set; }
        public VolunteerRequestsViewModel()
        {
            Members = new ObservableCollection<MemberViewModel>();
            SetPosts();
        }

        public void SetPosts()
        {
            var personService = new PersonService();
            Members.Clear();
            var temp = personService.GetMembers();
            _members = personService.GetPendingMembers();
            foreach (var member in _members)
            {
                Members.Add(new(member));
            }
        }

    }
}
