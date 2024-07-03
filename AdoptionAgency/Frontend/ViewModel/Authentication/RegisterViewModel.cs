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
            //memberService.Add(Member.ToMember());
            MessageBox.Show("Success!");
            return true;
        }
    }
}
