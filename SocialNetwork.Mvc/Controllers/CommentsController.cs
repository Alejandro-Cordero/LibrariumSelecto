using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Data;
using SocialNetwork.Mvc.Extensions;

namespace SocialNetwork.Mvc.Controllers
{
    public class CommentsController : Controller
    {
        private readonly SocialNetworkDbContext _socialNetworkDbContext;
        public CommentsController(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Commentary model, int id)
        {
            if (HttpContext.Session.GetObject<User>("UsuarioEnSession") != null)
            {
                model.Id = 0;
                model.Date = DateTime.Now;
                model.UserId = HttpContext.Session.GetObject<User>("UsuarioEnSession").Id;
                model.ArticleId = id;

                _socialNetworkDbContext.Commentaries.Add(model);
                await _socialNetworkDbContext.SaveChangesAsync();

                return Json(new { success = true });
            }

            return Json(new { success = false, redirectUrl = Url.Action("Login", "Users") });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var commentary = await _socialNetworkDbContext.Commentaries.FindAsync(id);
            if (commentary == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetObject<User>("UsuarioEnSession")?.Id != commentary.UserId)
            {
                return Forbid();
            }

            return PartialView("_EditComment", commentary); // Vista parcial para edición
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Commentary model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var commentary = await _socialNetworkDbContext.Commentaries.FindAsync(id);
            if (commentary == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.GetObject<User>("UsuarioEnSession")?.Id != commentary.UserId)
            {
                return Forbid();
            }

            commentary.Title = model.Title;
            commentary.Description = model.Description;
            commentary.Rating = model.Rating;
            commentary.Date = DateTime.Now;

            _socialNetworkDbContext.Commentaries.Update(commentary);
            await _socialNetworkDbContext.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
