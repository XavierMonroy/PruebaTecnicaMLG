using Microsoft.Data.SqlClient;
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
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SqlParameter> GetParemeterForStore(StoreViewModel store, bool isUpdate)
        {
            List<SqlParameter> parms = new List<SqlParameter>();

            if (isUpdate)
                parms.Add(new SqlParameter { ParameterName = "PKStore", Value = store.PKStore });

            parms.Add(new SqlParameter { ParameterName = "Subsidiary", Value = store.Subsidiary });
            parms.Add(new SqlParameter { ParameterName = "Address", Value = store.Address });
            parms.Add(new SqlParameter { ParameterName = "LastUpdated", Value = DateTime.Now });
            parms.Add(new SqlParameter { ParameterName = "IsAvailable", Value = store.IsAvailable });

            return parms;
        }

        public Store GetStoreByPK(int PKStore)
        {
            return _context.Stores.Find(PKStore);
        }
    }
}
