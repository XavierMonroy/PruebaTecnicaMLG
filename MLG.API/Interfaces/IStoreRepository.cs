using Microsoft.Data.SqlClient;
using MLG.API.ViewModels;
using MLG.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.Interfaces
{
    public interface IStoreRepository
    {
        List<SqlParameter> GetParemeterForStore(StoreViewModel store, bool isUpdate);

        public Store GetStoreByPK(int PKStore);
    }
}
