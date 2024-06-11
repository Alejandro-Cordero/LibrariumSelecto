using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Mvc.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
