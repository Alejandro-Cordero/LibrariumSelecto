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
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;
        private readonly IMapper _mapper;

        public RecommendationController(IRecommendationService recommendationService, IMapper mapper)
        {
            this._mapper = mapper;
            this._recommendationService = recommendationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<RecommendationResource>>> GetAllRecommendations()
        {
            var recommendations = await _recommendationService.GetAll();
            var recommendationResources = _mapper.Map<IEnumerable<Recommendation>, IEnumerable<RecommendationResource>>(recommendations);

            return Ok(recommendationResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendationResource>> GetRecommendationById(int id)
        {
            var recommendation = await _recommendationService.GetRecommendationById(id);
            var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(recommendation);

            return Ok(recommendationResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<RecommendationResource>> Create([FromBody] SaveRecommendationResource saveRecommendationResource)
        {
            var validator = new SaveRecommendationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveRecommendationResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var recommendationToCreate = _mapper.Map<SaveRecommendationResource, Recommendation>(saveRecommendationResource);

            var newRecommendation = await _recommendationService.CreateRecommendation(recommendationToCreate);

            var recommendation = await _recommendationService.GetRecommendationById(newRecommendation.Id);

            var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(recommendation);

            return Ok(recommendationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendation(int id)
        {
            if (id == 0)
                return BadRequest();

            var recommendation = await _recommendationService.GetRecommendationById(id);

            if (recommendation == null)
                return NotFound();

            await _recommendationService.DeleteRecommendation(recommendation);

            return NoContent();
        }


    }
}