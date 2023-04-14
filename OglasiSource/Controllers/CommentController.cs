using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OglasiSource.Api.Cqrs.Commands.Comment;
using OglasiSource.Api.Cqrs.Queries.Comment;
using OglasiSource.Core.Responses;
using OglasiSource.Core.Responses.Comment;
using OglasiSource.Core.Specifications.Comment;
using Swashbuckle.AspNetCore.Annotations;

namespace OglasiSource.Api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create comment.", Description = "Create comment.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateResponse>> CreateCommentAsync(CreateCommentCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update comment.", Description = "Update comment.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCommentAsync(UpdateCommentCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);

        }

        [HttpDelete("{Id}")]
        [SwaggerOperation(Summary = "Delete comment.", Description = "Delete comment.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCommentAsync([FromRoute] DeleteCommentCommand request)
        {
            var response = await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("{Id}")]
        [SwaggerOperation(Summary = "Get comment by id.", Description = "Get comment by id.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommentResponse>> GetCommentByIdAsync([FromRoute] GetCommentByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("list")]
        [SwaggerOperation(Summary = "Get comment list by entity type.", Description = "Get comment list by entity type.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CommentByEntityTypeListResponse>> GetCommentListAsync([FromQuery] CommentSpecParams request)
        {
            var response = await _mediator.Send(new GetCommentByEntityTypeListQuery { CommentSpecParams = request });
            return Ok(response);
        }

        [HttpGet("modal")]
        [SwaggerOperation(Summary = "Get data for comment modal.", Description = "Get data for comment modal.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetCommentModalResponse>> GetCommentModalAsync()
        {
            var response = await _mediator.Send(new GetCommentModalQuery());
            return Ok(response);
        }
    }
}
