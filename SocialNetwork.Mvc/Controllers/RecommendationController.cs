using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Data;
using SocialNetwork.Mvc.Extensions;

namespace SocialNetwork.Mvc.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly SocialNetworkDbContext _socialNetworkDbContext;
        public RecommendationController(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(Recommendation model, int articleId)
        {
            if(HttpContext.Session.GetObject<User>("UsuarioEnSession") != null)
            {
                model.Id = 0;
                model.Date = DateTime.Now;
                model.UserId = HttpContext.Session.GetObject<User>("UsuarioEnSession").Id;
                model.ArticleId = articleId;

                _socialNetworkDbContext.Recommendations.Add(model);
                await _socialNetworkDbContext.SaveChangesAsync();
                
                return RedirectToAction("GetArticleDetails", "Articles", new { id = articleId });
            }

            return RedirectToAction("Login", "Users");
        }

        public async Task<IActionResult> Delete(int recommendationId, int articleId)
        {
            var recommendation = _socialNetworkDbContext.Recommendations.Find(recommendationId);

            if(recommendation != null)
            {
                _socialNetworkDbContext.Recommendations.Remove(recommendation);
                await _socialNetworkDbContext.SaveChangesAsync();

                return RedirectToAction("GetArticleDetails", "Articles", new { id = articleId });
            }

            return RedirectToAction("Index", "Articles");
        }
    }
}
