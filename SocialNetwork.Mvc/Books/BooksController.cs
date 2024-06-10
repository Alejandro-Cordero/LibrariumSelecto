using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Mvc.Books
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync();
            return View(books);
        }
    }
}
