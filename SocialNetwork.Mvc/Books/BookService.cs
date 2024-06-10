using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using SocialNetwork.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SocialNetwork.Mvc.Books
{
    public class BookService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var webRootPath = _webHostEnvironment.WebRootPath;
            var filePath = Path.Combine(webRootPath, "data", "books.json");

            if (!File.Exists(filePath))
            {
                return new List<Book>();
            }

            var json = await File.ReadAllTextAsync(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
        }
    }
}
