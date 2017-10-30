using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatShop.Models.EF.MoreEF
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}