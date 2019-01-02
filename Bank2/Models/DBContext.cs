using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank2.Models
{
    public class DBContext
    {
        public User GetUser(int id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return new List<User>
            {
                new User{ Id=1,
                    FirstName = "Stefan", LastName="Holmberg",
                    BirthYear = 1972,
                    City = "Stockholm",
                    Accounts = new List<Account>{
                        new Account{  AccountNumber="1244",Balance=22, Type=Account.AccountType.Savings },
                        new Account{  AccountNumber="12313458-3",Balance=100, Type=Account.AccountType.Savings }
                } },
                new User{ Id=2,FirstName = "Lisa",
                    LastName ="Bengtsson",
                    BirthYear = 1972,
                    City = "Uppsala",
                    Accounts = new List<Account>{
                        new Account{  AccountNumber="44343.4",Balance=645, Type=Account.AccountType.Transaction }
                } },
                new User{ Id=3,FirstName = "Mia",
                    LastName ="Magnusson",
                    BirthYear = 1980,
                    City = "Uppsala",
                    Accounts = new List<Account>{
                        new Account{  AccountNumber="1235775-2",Balance=1645, Type=Account.AccountType.Transaction },
                        new Account{  AccountNumber="1235778-2",Balance=99, Type=Account.AccountType.Transaction },
                        new Account{  AccountNumber="333232",Balance=4500, Type=Account.AccountType.Savings }
                } }

            };
        }


    }
}