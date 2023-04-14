using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using OglasiSource.Api.Cqrs.Commands.RatingReview;
using OglasiSource.Api.Cqrs.Queries.RatingReview;
using OglasiSource.Core.Responses;
using OglasiSource.Core.Responses.RatingReview;
using OglasiSource.Core.Specifications.Review;

namespace OglasiSource.Api.Controllers
{
    [Route("api/ratingreview")]
    [ApiController]
    public class RatingReviewController : ControllerBase
    {

        private readonly IMediator _mediator;

        public RatingReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("rating")]
        [SwaggerOperation(Summary = "Give rating.", Description = "Give rating.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RatingSetResponse>> GiveRatingAsync(CreateRatingCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("review")]
        [SwaggerOperation(Summary = "Create review.", Description = "Create review.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateResponse>> CreateReviewAsync(CreateReviewCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("review")]
        [SwaggerOperation(Summary = "Update review.", Description = "Update review.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateReviewAsync(UpdateReviewCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("review/{Id}")]
        [SwaggerOperation(Summary = "Delete review.", Description = "Delete review.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReviewAsync([FromRoute] DeleteReviewCommand request)
        {
            var response = await _mediator.Send(request);
            return NoContent();
        }
        [HttpGet("review/{Id}")]
        [SwaggerOperation(Summary = "Get review by id.", Description = "Get review by id.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReviewResponse>> GetReviewByIdAsync([FromRoute] GetReviewByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("review/list")]
        [SwaggerOperation(Summary = "Get review list.", Description = "Get review list.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReviewByEntityTypeListResponse>> GetReviewListAsync([FromQuery] ReviewSpecParams request)
        {
            var response = await _mediator.Send(new ReviewbByEntityTypeListQuery { ReviewSpecParams = request });
            return Ok(response);
        }

        [HttpGet("modal")]
        [SwaggerOperation(Summary = "Get data for rating and review modal.", Description = "Get data for rating and review modal.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetRatingReviewModalResponse>> GetRatingReviewModalAsync()
        {
            var response = await _mediator.Send(new GetRatingReviewModalQuery());
            return Ok(response);
        }

    }
}
