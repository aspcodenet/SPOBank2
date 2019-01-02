using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Bank2.ViewModels
{
    public class EditAccountViewModel
    {
        public int Id { get; set; }
        [DisplayName("Förnamn")]
        public string Fornamn { get; set; }
        [DisplayName("Efternamn")]
        public string Efternamn { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Födelseår")]
        public int Birthyear { get; set; }
    }
}