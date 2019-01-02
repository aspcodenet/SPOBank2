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
        public ActionResult SaveAccount(EditAccountViewModel modified)
        {
            int id = modified.Id;
            var dbContext = new DBContext();
            var userModel = dbContext.GetUser(id);
            userModel.BirthYear = modified.Birthyear;
            userModel.FirstName = modified.Fornamn;
            userModel.LastName = modified.Efternamn;
            userModel.City = modified.City;

            return View("NewAccount");
        }
        public ActionResult SaveNewAccount(EditAccountViewModel user)
        {
            if(user.Birthyear < 1900)
            {
                return View("NewAccount", user);
            }

            //Allt OK
            var dbContext = new DBContext();
            //spara!!

            return View();
        }

        public ActionResult NewAccount()
        {
            var model = new EditAccountViewModel();
            return View(model);
        }

        public ActionResult EditUser(int id)
        {
            var dbContext = new DBContext();
            var user = dbContext.GetUser(id);
            var model = new EditAccountViewModel
            {
                Birthyear = user.BirthYear,
                City = user.City,
                Efternamn = user.LastName,
                Fornamn = user.FirstName,
                Id = user.Id
            };
            return View(model);
        }


        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAccountsForUser(int id)
        {
            var dbContext = new DBContext();
            var user = dbContext.GetUser(id);
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
            var dbContext = new DBContext();
            foreach (var user in dbContext.GetAllUsers())
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
            var dbContext = new DBContext();
            var user = dbContext.GetUser(id);
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




    }
}