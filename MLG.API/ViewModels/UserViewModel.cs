using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.ViewModels
{
    public class UserViewModel
    {
        public string username { get; set; }

        public string Token { get; set; }
    }
}