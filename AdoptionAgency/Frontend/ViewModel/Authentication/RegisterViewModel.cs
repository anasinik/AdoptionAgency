using AdoptionAgency.Backend.Domain.Model.User;
using AdoptionAgency.Backend.Services;
using AdoptionAgency.Frontend.ViewModel.MemberVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdoptionAgency.Frontend.ViewModel.Authentication
{
    public class RegisterViewModel
    {
        public MemberViewModel Member{ get; set; }

        public RegisterViewModel()
        {
            Member = new MemberViewModel();
        }
        public bool SignUp()
        {
            var personService = new PersonService();
            var user = new User(Member.User.Username, Member.User.Password, Backend.Domain.Model.Common.Status.Pending);
            Member.User = user;
            personService.Add(Member.ToMember());
            MessageBox.Show("Success!");
            return true;
        }
    }
}
