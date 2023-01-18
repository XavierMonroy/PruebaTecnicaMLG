using Microsoft.Data.SqlClient;
using MLG.API.ViewModels;
using MLG.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLG.API.Interfaces
{
    public interface IArticleRepository
    {
        public Article GetArticleByPK(int PKArticle);
        public ArticleStore GetArticleStoreByPK(int PKArticleStore);

    }
}
