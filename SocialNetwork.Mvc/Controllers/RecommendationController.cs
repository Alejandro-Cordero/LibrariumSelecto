using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Data;
using SocialNetwork.Mvc.Extensions;
using System.Threading.Tasks;

namespace SocialNetwork.Mvc.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly SocialNetworkDbContext _socialNetworkDbContext;

        public RecommendationController(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }

        [HttpPost("Recommendation/Create/{articleId}")]
        public async Task<IActionResult> Create(int articleId)
        {
            var currentUser = HttpContext.Session.GetObject<User>("UsuarioEnSession");
            if (currentUser != null)
            {
                var recommendation = new Recommendation
                {
                    Date = DateTime.Now,
                    UserId = currentUser.Id,
                    ArticleId = articleId
                };

                _socialNetworkDbContext.Recommendations.Add(recommendation);
                await _socialNetworkDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Articles", new { id = articleId });
        }

        [HttpPost("Recommendation/Delete/{recommendationId}/{articleId}")]
        public async Task<IActionResult> Delete(int recommendationId, int articleId)
        {
            var recommendation = _socialNetworkDbContext.Recommendations.Find(recommendationId);

            if (recommendation != null)
            {
                _socialNetworkDbContext.Recommendations.Remove(recommendation);
                await _socialNetworkDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Articles", new { id = articleId });
        }
    }
}
