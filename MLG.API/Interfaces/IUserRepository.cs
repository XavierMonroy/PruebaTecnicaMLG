using Microsoft.Data.SqlClient;
using MLG.API.ViewModels;
using MLG.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExist(string username);
        List<SqlParameter> GetParemeterForCustomer(CustomerViewModel customer, bool isUpdate);
        public CustomerArticle GetCustomerArticleByPK(int PKCustomerArticle);
    }
}
