using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank2.Models
{
    public class Account
    {
        public enum AccountType
        {
            Savings,
            Transaction
        }
        public string AccountNumber { get; set; }
        public float Balance { get; set; }
        public AccountType Type { get; set; }
    }
}