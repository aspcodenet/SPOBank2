using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank2.ViewModels
{
    public class ShowAccountsForUserAccountViewModel
    {
        public string AccountNo { get; set; }
        public string Text { get; set; }
    }

    public class ShowAccountsForUserViewModel
    {

        public ShowAccountsForUserViewModel()
        {
            Accounts = new List<ShowAccountsForUserAccountViewModel>();
        }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public List<ShowAccountsForUserAccountViewModel> Accounts{ get; set; }
    }
}