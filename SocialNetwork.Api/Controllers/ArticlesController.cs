using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Resources;
using SocialNetwork.Api.Validators;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.Services;

namespace SocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            this._articleService = articleService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ArticleResource>>> GetAllArticles()
        {
            var articles = await _articleService.GetAll();
            var articleResources = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResource>>(articles);

            return Ok(articleResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleResource>> GetArticleById(int id)
        {
            var article = await _articleService.GetArticleById(id);
            var articleResource = _mapper.Map<Article, ArticleResource>(article);

            return Ok(articleResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ArticleResource>> CreateArticle([FromBody] SaveArticleResource saveArticleResource)
        {
            var validator = new SaveArticleResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArticleResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var articleToCreate = _mapper.Map<SaveArticleResource, Article>(saveArticleResource);

            var newArticle = await _articleService.CreateArticle(articleToCreate);

            var article = await _articleService.GetArticleById(newArticle.Id);

            var articleResource = _mapper.Map<Article, ArticleResource>(article);

            return Ok(articleResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleResource>> UpdateArticle(int id, [FromBody] SaveArticleResource saveArticleResource)
        {
            var validator = new SaveArticleResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArticleResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var articleToBeUpdate = await _articleService.GetArticleById(id);

            if (articleToBeUpdate == null)
                return NotFound();

            var article = _mapper.Map<SaveArticleResource, Article>(saveArticleResource);

            await _articleService.UpdateArticle(articleToBeUpdate, article);

            var updatedArticle = await _articleService.GetArticleById(id);

            var updatedArticleResource = _mapper.Map<Article, ArticleResource>(updatedArticle);

            return Ok(updatedArticleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            if (id == 0)
                return BadRequest();

            var article = await _articleService.GetArticleById(id);

            if (article == null)
                return NotFound();

            await _articleService.DeleteArticle(article);

            return NoContent();
        }

        //[HttpGet]
        //public IActionResult Search([FromBody] Search model)
        //{
        //    List<Article> results = new List<Article>();
        //    results.Where(x => x.User.Equals(model.Author)).ToList();

        //    results.Where(x => x.Content.Equals(model.Content)).ToList();

        //    results.Where(x => model.FirstDate < x.CreationDate).Where(x => x.CreationDate > model.LastDate).ToList();

        //    return Ok(results);
        //}
    }
}
