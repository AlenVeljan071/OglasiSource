using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OglasiSource.Api.Cqrs.Commands.Advertisement;
using OglasiSource.Api.Cqrs.Commands.Image;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Api.Cqrs.Queries.Image;
using OglasiSource.Core.Responses;
using OglasiSource.Core.Responses.Advertisements;
using OglasiSource.Core.Responses.Image;
using OglasiSource.Core.Specifications.Advertisement;
using Swashbuckle.AspNetCore.Annotations;

namespace OglasiSource.Api.Controllers
{
    [Route("api/advertisements")]
    [ApiController]
    [Authorize]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdvertisementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create advertisement.", Description = "Create advertisement.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateResponse>> CreateAdvertisementAsync(CreateAdvertisementCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut()]
        [SwaggerOperation(Summary = "Edit advertisement for user.", Description = "Edit advertisement for user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Unit>> EditAdvertisementAsync(UpdateAdvertisementCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [SwaggerOperation(Summary = "Delete advertisement for user.", Description = "Delete advertisement for user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAdvertisementAsync([FromRoute] DeleteAdvertisementCommand request)
        {
            var response = await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("{Id}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Get advertisement by id.", Description = "Get advertisement by id.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AdvertisementResponse>> GetAdvertisementByIdAsync([FromRoute] GetAdvertisementByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("list")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Get advertisement list.", Description = "Get advertisement list.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AdvertisementListResponse>> GetAdvertisementListAsync([FromQuery] AdvertisementSpecParams request)
        {
            var response = await _mediator.Send(new GetAdvertisementsListQuery { AdvertisementSpecParams = request });
            return Ok(response);
        }

        [HttpGet("modal")]
        [SwaggerOperation(Summary = "Get data for advertisement modal.", Description = "Get data for advertisement modal.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAdvertisementModalResponse>> GetDataForAdvertisementModalAsync()
        {
            var response = await _mediator.Send(new GetAdvertisementModalQuery());
            return Ok(response);
        }

        [HttpGet("vehiclemodel/{Id}")]
        [SwaggerOperation(Summary = "Get data for vehiclemodel modal.", Description = "Get data for vehiclemodel modal.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VehicleModelResponse>> GetVehicleModelByBrandIdAsync([FromRoute] GetVehicleModelByBrandIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("image")]
        [SwaggerOperation(Summary = "Create album trainer.", Description = "Create album trainer.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ImageResponse>> CreateAlbumAsync(UploadImageCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("image/{Id}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Get image trainer by id.", Description = "Get image trainer by id.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Core.Classes.Image>> GetImageTrainerByIdAsync([FromRoute] GetImageTrainerByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
