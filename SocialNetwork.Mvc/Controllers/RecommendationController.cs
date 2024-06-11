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

        [HttpPost]
        public async Task<IActionResult> Create(Recommendation model, int articleId)
        {
            if (HttpContext.Session.GetObject<User>("UsuarioEnSession") != null)
            {
                model.Id = 0;
                model.Date = DateTime.Now;
                model.UserId = HttpContext.Session.GetObject<User>("UsuarioEnSession").Id;
                model.ArticleId = articleId;

                _socialNetworkDbContext.Recommendations.Add(model);
                await _socialNetworkDbContext.SaveChangesAsync();

                return Json(new { success = true, recommendationId = model.Id });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int recommendationId)
        {
            var recommendation = _socialNetworkDbContext.Recommendations.Find(recommendationId);

            if (recommendation != null)
            {
                _socialNetworkDbContext.Recommendations.Remove(recommendation);
                await _socialNetworkDbContext.SaveChangesAsync();

               return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}
