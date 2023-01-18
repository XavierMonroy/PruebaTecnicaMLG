using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MLG.API.Interfaces;
using MLG.API.ViewModels;
using MLG.DataAccess;
using MLG.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExist(string username)
        {
            return await _context.Customers.AnyAsync(c => c.User == username.ToLower());
        }

        public List<SqlParameter> GetParemeterForCustomer(CustomerViewModel customer, bool isUpdate)
        {
            List<SqlParameter> parms = new List<SqlParameter>();

            if (isUpdate)
                parms.Add(new SqlParameter { ParameterName = "PKCustomer", Value = customer.PKCustomer });

            parms.Add(new SqlParameter { ParameterName = "Name", Value = customer.Name });
            parms.Add(new SqlParameter { ParameterName = "LastName", Value = customer.LastName });
            parms.Add(new SqlParameter { ParameterName = "Address", Value = customer.Address });
            parms.Add(new SqlParameter { ParameterName = "User", Value = customer.User.ToLower() });
            parms.Add(new SqlParameter { ParameterName = "Password", Value = customer.Password });
            parms.Add(new SqlParameter { ParameterName = "LastUpdated", Value = DateTime.Now });
            parms.Add(new SqlParameter { ParameterName = "IsAvailable", Value = customer.IsAvailable });

            return parms;
        }

        public CustomerArticle GetCustomerArticleByPK(int PKCustomerArticle)
        {
            return _context.CustomerArticles.Find(PKCustomerArticle);
        }
    }
}
