using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank2.ViewModels
{
    public class ShowUserViewModel
    {
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public int AntalKonton { get; set; }
        public float TotalSumma { get; set; }
        public int Id { get; set; }
    }
}