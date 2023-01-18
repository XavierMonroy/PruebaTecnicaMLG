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
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public Article GetArticleByPK(int PKArticle)
        {
            return _context.Articles.Find(PKArticle);
        }

        public ArticleStore GetArticleStoreByPK(int PKArticleStore)
        {
            return _context.ArticleStores.Find(PKArticleStore);
        }
    }
}
