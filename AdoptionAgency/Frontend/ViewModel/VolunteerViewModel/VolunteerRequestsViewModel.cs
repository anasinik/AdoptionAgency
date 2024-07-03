using AdoptionAgency.Backend.Services;
using AdoptionAgency.Frontend.ViewModel.MemberVM;
using System.Collections.ObjectModel;
using AdoptionAgency.Backend.Domain.Model.Person.Member;
using System.ComponentModel;
using System.Windows.Data;

namespace AdoptionAgency.Frontend.ViewModel.VolunteerViewModel
{
    public class VolunteerRequestsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MemberViewModel> _members;
        public ObservableCollection<MemberViewModel> Members => _members;
        private MemberViewModel _selectedMember;
        public MemberViewModel SelectedMember
        {
            get => _selectedMember;
            set 
            {
                _selectedMember = value;
                OnPropertyChanged();
            }
        }
        public ICollectionView MembersView { get; }
        public VolunteerRequestsViewModel()
        {
            var personService = new PersonService();
            _members = new ObservableCollection<MemberViewModel>();
            foreach (var member in personService.GetMembers())
            {
                _members.Add(new MemberViewModel((Member)member));
            }
        MembersView = new ListCollectionView(_members);
        }
    }
}
