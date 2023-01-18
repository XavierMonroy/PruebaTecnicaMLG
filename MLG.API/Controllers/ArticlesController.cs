using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLG.DataAccess;
using MLG.API.ViewModels;
using MLG.Models.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text;
using MLG.API.Interfaces;
using Microsoft.Data.SqlClient;
using MLG.Models.StoredProcedures;
using Microsoft.AspNetCore.Authorization;

namespace MLG.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AppDbContextForSP _contextSP;
        private readonly IArticleRepository _articleService;

        public ArticlesController(AppDbContext context, AppDbContextForSP contextSP, IArticleRepository articleService)
        {
            _context = context;
            _contextSP = contextSP;
            _articleService = articleService;
        }

        [HttpGet("GetArticlesByAvailable/{available}")]
        public async Task<ActionResult<ArticlesDropDownModel>> GetArticlesByAvailable(bool available)
        {
            try
            {
                var articles = await _context.Articles.Where(x => x.IsAvailable == available).Select(c => new ArticlesDropDownModel
                {
                    PKArticle = c.PKArticle,
                    Description = c.Code + '-' + c.Description
                }).ToListAsync();

                return Ok(articles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }


        [HttpGet("GetAllArticles")]
        [AllowAnonymous]
        public async Task<ActionResult<ArticleViewModel>> GetAllArticles()
        {
            try
            {
                List<ArticleViewModel> articles = await _context.Articles.Select(e => new ArticleViewModel
                {
                    PKArticle = e.PKArticle,
                    ArticleName = e.ArticleName,
                    Code = e.Code,
                    Description = e.Description,
                    Price = e.Price,
                    Image = e.Image,
                    Stock = e.Stock,
                    LastUpdated = e.LastUpdated,
                    IsAvailable = (bool)e.IsAvailable
                }).ToListAsync();

                return Ok(articles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("createArticle")]
        public async Task<IActionResult> CreateArticle(Article articleData)
        {
            try
            {
                var article = new Article
                {
                    Code = articleData.Code,
                    Description = articleData.Description,
                    Price = articleData.Price,
                    Image = articleData.Image,
                    Stock = articleData.Stock,
                    LastUpdated = DateTime.Now,
                    IsAvailable = articleData.IsAvailable
                };

                //_context.Articles.Add(article);
                await _context.SaveChangesAsync();

                return Ok("ResponseMessages.SuccessfulCreation");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPut("updateArticle")]
        public async Task<IActionResult> UpdateArticle(Article articleData)
        {
            try
            {
                Article article = _articleService.GetArticleByPK(articleData.PKArticle);
                article.Code = articleData.Code;
                article.Description = articleData.Description;
                article.Price = articleData.Price;
                article.Image = articleData.Image;
                article.Stock = articleData.Stock;
                article.LastUpdated = DateTime.Now;
                article.IsAvailable = articleData.IsAvailable;

                await _context.SaveChangesAsync();

                return Ok("ResponseMessages.SuccessfulUpdate");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPost("createArticleStore")]
        public async Task<IActionResult> CreateArticleStore(ArticleStore articleStoreData)
        {
            try
            {
                var articleStore = new ArticleStore
                {
                    FKArticle = articleStoreData.FKArticle,
                    FKStore = articleStoreData.FKStore,
                    LastUpdated = DateTime.Now,
                    IsAvailable = articleStoreData.IsAvailable
                };

                //_context.ArticleStores.Add(articleStore);
                await _context.SaveChangesAsync();

                return Ok("ResponseMessages.SuccessfulCreation");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        [HttpPut("updateArticleStore")]
        public async Task<IActionResult> UpdateArticleStore(ArticleStore articleStoreData)
        {
            try
            {
                ArticleStore articleStore = _articleService.GetArticleStoreByPK(articleStoreData.PKArticleStore);
                articleStore.FKArticle = articleStoreData.FKArticle;
                articleStore.FKStore = articleStoreData.FKStore;
                articleStore.LastUpdated = DateTime.Now;
                articleStore.IsAvailable = articleStoreData.IsAvailable;

                await _context.SaveChangesAsync();

                return Ok("ResponseMessages.SuccessfulUpdate");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

    }
}