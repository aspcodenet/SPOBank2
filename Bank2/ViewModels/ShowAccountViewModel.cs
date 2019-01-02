using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank2.ViewModels
{
    public class ShowAccountViewModel
    {
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public float Saldo { get; set; }

    }
}