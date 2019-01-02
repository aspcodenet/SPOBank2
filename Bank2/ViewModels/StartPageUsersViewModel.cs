using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank2.ViewModels
{
    public class StartPageUserViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class StartPageViewModel
    {
        public StartPageViewModel()
        {
            Users = new List<StartPageUserViewModel>();
        }
        public List<StartPageUserViewModel> Users { get; set; }
    }
}