using KonradBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonradBlog.Services
{
    public class ArticleService
    {
        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Article> GetAllArticles()
        {
            var articles = _context.Articles.ToList();
            return articles;
        }

        public string CreateArticle(Article article)
        {
            try
            {
                _context.Add(article);
                _context.SaveChanges();

                return "Saved Successfully";
            }
            catch (Exception e)
            {
                return e.StackTrace;
            }
        }

        public Article GetArticle(long id)
        {
            Article article = _context.Articles.FirstOrDefault(x => x.Id == id);
            return article;
        }

        public string UpdateArticle(Article article)
        {
            try
            {
                _context.Articles.Update(article);
                _context.SaveChanges();

                return "Updated Successfully";
            }
            catch (Exception e)
            {
                return e.StackTrace;
            }
        }

        public string DeleteArticle(Article article)
        {
            try
            {
                _context.Remove(article);
                _context.SaveChanges();

                return "Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.StackTrace;
            }
        }
    }
}
