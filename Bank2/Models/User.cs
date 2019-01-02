using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank2.Models
{
    public class User
    {
        public User()
        {
            Accounts = new List<Account>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; }
    }
}