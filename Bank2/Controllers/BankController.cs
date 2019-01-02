using Bank2.Models;
using Bank2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank2.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAccountsForUser(int id)
        {
            var user = GetUser(id);
            var viewModel = new ShowAccountsForUserViewModel();
            viewModel.Fornamn = user.FirstName;
            viewModel.Efternamn = user.LastName;
            foreach(var account in user.Accounts)
            {
                var accountViewModel = new ShowAccountsForUserAccountViewModel();
                accountViewModel.AccountNo = account.AccountNumber;
                if (account.Type == Account.AccountType.Savings)
                    accountViewModel.Text = "Sparkonto";
                if (account.Type == Account.AccountType.Transaction)
                    accountViewModel.Text = "Transaktionskonto";
                viewModel.Accounts.Add(accountViewModel);
            }
            return View(viewModel);
        }

        public ActionResult ShowAccount(string accountNo)
        {
            foreach(var user in GetAllUsers())
            {
                var account = user.Accounts.FirstOrDefault(r => r.AccountNumber == accountNo);
                if(account != null)
                {
                    var viewModel = new ShowAccountViewModel
                    {
                        AccountNo = account.AccountNumber,
                        Efternamn = user.LastName,
                        Fornamn = user.FirstName,
                        Saldo = account.Balance
                    };
                    if (account.Type == Account.AccountType.Savings)
                        viewModel.AccountType = "Sparkonto";
                    if (account.Type == Account.AccountType.Transaction)
                        viewModel.AccountType = "Transaktionskonto";
                    return View(viewModel);
                }
            }
            return null;
        }

        public ActionResult ShowUser(int id)
        {
            var user = GetUser(id);
            var showUserViewModel = new ShowUserViewModel
            {
                Efternamn = user.LastName,
                Fornamn = user.FirstName,
                AntalKonton = user.Accounts.Count(),
                TotalSumma = user.Accounts.Sum(r => r.Balance),
                Id = user.Id
            };

            return View(showUserViewModel);
        }


        protected User GetUser(int id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == id);
        }


        protected List<User> GetAllUsers()
        {
            return new List<User>
            {
                new User{ Id=1,FirstName = "Stefan", LastName="Holmberg", Accounts = new List<Account>{
                    new Account{  AccountNumber="1244",Balance=22, Type=Account.AccountType.Savings },
                    new Account{  AccountNumber="12313458-3",Balance=100, Type=Account.AccountType.Savings }
                } },
                new User{ Id=2,FirstName = "Lisa", LastName="Bengtsson", Accounts = new List<Account>{
                    new Account{  AccountNumber="44343.4",Balance=645, Type=Account.AccountType.Transaction }
                } },
                new User{ Id=3,FirstName = "Mia", LastName="Magnusson", Accounts = new List<Account>{
                    new Account{  AccountNumber="1235775-2",Balance=1645, Type=Account.AccountType.Transaction },
                    new Account{  AccountNumber="1235778-2",Balance=99, Type=Account.AccountType.Transaction },
                    new Account{  AccountNumber="333232",Balance=4500, Type=Account.AccountType.Savings }
                } }

            };
        }

    }
}