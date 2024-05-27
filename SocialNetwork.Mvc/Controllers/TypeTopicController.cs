using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Mvc.Controllers
{
    public class TypeTopicController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeTopicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //return Json(new { data = _unitOfWork.TypeTopic.GetAll() });
            IEnumerable<TypeTopic> data = await _unitOfWork.TypeTopicRepo.GetAllAsync();
            return Json(new { data = data });
        }
    }
}
