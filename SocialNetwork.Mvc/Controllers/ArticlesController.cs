using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core;
using SocialNetwork.Core.Models;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.ViewModels;
using SocialNetwork.Mvc.Extensions;
using SocialNetwork.Mvc.Models;
using SocialNetwork.Mvc.Models.ViewModels;

namespace SocialNetwork.Mvc.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly SocialNetworkDbContext socialNetworkDbContext;

        public ArticlesController(SocialNetworkDbContext contexto)
        {
            socialNetworkDbContext = contexto;
        }

        public async Task<IActionResult> Index(Search model, int? id, int page = 1, int pageSize = 6)
        {
            List<Article> results = new List<Article>();
            results = await socialNetworkDbContext.Articles.ToListAsync();

            List<User> users = new List<User>();
            users = await socialNetworkDbContext.Users.ToListAsync();

            if (!string.IsNullOrEmpty(model.Author))
            {
                User user = users.Where(x => x.Login.Equals(model.Author)).First();
                results = results.Where(x => x.UserId.Equals(user.Id)).ToList();
            }

            if (!string.IsNullOrEmpty(model.Content))
            {
                results = results.Where(x => x.Content.Contains(model.Content)).ToList();
            }

            if (model.FirstDate != null && model.LastDate != null)
            {
                results = results.Where(x => x.CreationDate >= model.FirstDate && x.CreationDate <= model.LastDate).ToList();
            }

            if (id != null)
            {
                results = results.Where(x => x.UserId == id).ToList();
            }

            //Paginación de los resultados
            var resultadoPaginado = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new IndexViewModel
            {
                Users = MapperDTO.ListUsers(await socialNetworkDbContext.Users.ToListAsync()),
                Articles = MapperDTO.ListArticles(resultadoPaginado),
                TypeTopics = MapperDTO.ListTopics(await socialNetworkDbContext.TypeTopics.ToListAsync()),
                Recommendations = MapperDTO.ListRecommendations(await socialNetworkDbContext.Recommendations.ToListAsync()),
                Commentaries = MapperDTO.ListComments(await socialNetworkDbContext.Commentaries.ToListAsync()),
                PageIndex = page,
                TotalPages = (int) Math.Ceiling(results.Count / (double)pageSize)
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Article article)
        {
            if (ModelState.IsValid)
            {
                article.UserId = HttpContext.Session.GetObject<User>("UsuarioEnSession").Id;
                article.CreationDate = DateTime.Now;
                socialNetworkDbContext.Articles.Add(article);
                await socialNetworkDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Articles");
            }

            return View();
        }

        public async Task<IActionResult> GetArticleDetails(int? id)
        {
            if (id == null && HttpContext.Session.GetObject<User>("UsuarioEnSession") != null)
            {
                return RedirectToAction("Create", "Articles");
            }
            else if(id == null)
            {
                return RedirectToAction("Login", "Users");
            }

            List<Article> articles = new List<Article>();
            articles = await socialNetworkDbContext.Articles.ToListAsync();
            List<User> users = new List<User>();
            users = await socialNetworkDbContext.Users.ToListAsync();
            List<TypeTopic> typeTopics = new List<TypeTopic>();
            typeTopics = await socialNetworkDbContext.TypeTopics.ToListAsync();
            List<Commentary> comments = new List<Commentary>();
            comments = await socialNetworkDbContext.Commentaries.ToListAsync();
            List<Recommendation> recommendations = new List<Recommendation>();
            recommendations = await socialNetworkDbContext.Recommendations.ToListAsync();

            Article article = articles.FirstOrDefault(x => x.Id == id);
            User user = users.FirstOrDefault(x => x.Id == article.UserId);
            TypeTopic topic = typeTopics.FirstOrDefault(x => x.Id == article.TypeTopicId);
            comments = comments.Where(x => x.ArticleId == id).ToList();
            recommendations = recommendations.Where(x => x.ArticleId == id).ToList();

            var viewModel = new ArticleDetail
            {
                User = MapperDTO.MapUsuario(user),
                Article = MapperDTO.MapArticle(article),
                TypeTopic = MapperDTO.MapTopic(topic),
                Commentaries = MapperDTO.ListComments(comments),
                Recommendations = MapperDTO.ListRecommendations(recommendations)
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Search model, int? id, int page = 1, int pageSize = 5)
        {
            // Tu lógica para obtener los artículos filtrados según el modelo de búsqueda
            List<Article> results = new List<Article>();
            results = await socialNetworkDbContext.Articles.ToListAsync();

            List<User> users = new List<User>();
            users = await socialNetworkDbContext.Users.ToListAsync();

            if (!string.IsNullOrEmpty(model.Author))
            {
                User user = users.Where(x => x.Login.Equals(model.Author)).First();
                results = results.Where(x => x.UserId.Equals(user.Id)).ToList();
            }

            if (!string.IsNullOrEmpty(model.Content))
            {
                results = results.Where(x => x.Content.Contains(model.Content)).ToList();
            }

            if (model.FirstDate != null && model.LastDate != null)
            {
                results = results.Where(x => x.CreationDate >= model.FirstDate && x.CreationDate <= model.LastDate).ToList();
            }

            //paginación de los resultados
            var resultadoPaginado = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new IndexViewModel
            {
                Users = MapperDTO.ListUsers(await socialNetworkDbContext.Users.ToListAsync()),
                Articles = MapperDTO.ListArticles(resultadoPaginado),
                TypeTopics = MapperDTO.ListTopics(await socialNetworkDbContext.TypeTopics.ToListAsync()),
                Recommendations = MapperDTO.ListRecommendations(await socialNetworkDbContext.Recommendations.ToListAsync()),
                Commentaries = MapperDTO.ListComments(await socialNetworkDbContext.Commentaries.ToListAsync()),
                PageIndex = page,
                TotalPages = (int)Math.Ceiling(results.Count / (double)pageSize)
            };

            // Redirigir a la acción Index con el ID del usuario en sesión en la ruta
            return RedirectToAction("Index", new { id = HttpContext.Session.GetObject<User>("UsuarioEnSession").Id });
        }

        [HttpPost]
        public IActionResult Update(int id, string title, string content)
        {

            var article = socialNetworkDbContext.Articles.Find(id);

            if (article == null)
            {
                return RedirectToAction("Index");
            }

            article.Title = title;
            article.Content = content;

            socialNetworkDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
