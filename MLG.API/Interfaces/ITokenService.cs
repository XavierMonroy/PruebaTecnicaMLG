using MLG.API.ViewModels;
using MLG.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Customer user);
    }
}
