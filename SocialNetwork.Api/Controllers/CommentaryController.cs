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
    public class CommentaryController : ControllerBase
    {
        private readonly ICommentaryService _commentaryService;
        private readonly IMapper _mapper;

        public CommentaryController(ICommentaryService commentaryService, IMapper mapper)
        {
            this._mapper = mapper;
            this._commentaryService = commentaryService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CommentaryResource>>> GetAllUsers()
        {
            var commentaries = await _commentaryService.GetAll();
            var commentaryResources = _mapper.Map<IEnumerable<Commentary>, IEnumerable<CommentaryResource>>(commentaries);

            return Ok(commentaryResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentaryResource>> GetCommentaryById(int id)
        {
            var commentary = await _commentaryService.GetCommentById(id);
            var commentaryResource = _mapper.Map<Commentary, CommentaryResource>(commentary);

            return Ok(commentaryResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CommentaryResource>> CreateComment([FromBody] SaveCommentaryResource saveCommentaryResource)
        {
            var validator = new SaveCommentaryResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCommentaryResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var commentaryToCreate = _mapper.Map<SaveCommentaryResource, Commentary>(saveCommentaryResource);

            var newCommentary = await _commentaryService.CreateComment(commentaryToCreate);

            var commentary = await _commentaryService.GetCommentById(newCommentary.Id);

            var commentaryResource = _mapper.Map<Commentary, CommentaryResource>(commentary);

            return Ok(commentaryResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommentaryResource>> UpdateComment(int id, [FromBody] SaveCommentaryResource saveCommentaryResource)
        {
            var validator = new SaveCommentaryResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCommentaryResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var commentaryToBeUpdate = await _commentaryService.GetCommentById(id);

            if (commentaryToBeUpdate == null)
                return NotFound();

            var commentary = _mapper.Map<SaveCommentaryResource, Commentary>(saveCommentaryResource);

            await _commentaryService.UpdateComment(commentaryToBeUpdate, commentary);

            var updatedComment = await _commentaryService.GetCommentById(id);

            var updatedCommentResource = _mapper.Map<Commentary, CommentaryResource>(updatedComment);

            return Ok(updatedCommentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentary(int id)
        {
            if (id == 0)
                return BadRequest();

            var commentary = await _commentaryService.GetCommentById(id);

            if (commentary == null)
                return NotFound();

            await _commentaryService.DeleteComment(commentary);

            return NoContent();
        }
    }
}
