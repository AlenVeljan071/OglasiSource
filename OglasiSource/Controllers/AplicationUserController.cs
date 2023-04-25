using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPersonalTrainer.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Cqrs.Commands.Account;
using OglasiSource.Api.Cqrs.Commands.Advertisement;
using OglasiSource.Api.Cqrs.Queries.Account;
using OglasiSource.Api.Cqrs.Queries.Advertisement;
using OglasiSource.Core.Responses.Account;
using OglasiSource.Core.Responses.Advertisements;
using Swashbuckle.AspNetCore.Annotations;

namespace OglasiSource.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AplicationUserController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signupadminaccount")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Sign up admin account for free trial.", Description = "Sign up admin account for free trial.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignupVerifyResponse>> SignUpTrainerAccountAsync(SignAdminAccountCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("signupaccount")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Sign up  account for free trial.", Description = "Sign up account for free trial.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignupVerifyResponse>> SignUpAccountAsync(SignAccountCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "User login.", Description = "User login with email and password.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignInResponse>> LoginAsync(SignInCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPut()]
        [SwaggerOperation(Summary = "Edit user.", Description = "Edit user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Unit>> EditApplicationUserAsync(EditAccountCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [SwaggerOperation(Summary = "Get user by id.", Description = "Get user by id.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApplicationUserResponse>> GetUserByIdAsync([FromRoute] GetUserByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("resendsignupuser")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Resend signup user.", Description = "Resend signup user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignupVerifyResponse>> ResendSignUpUserAsync(ResendSignUpUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("verifyuser")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Verify user.", Description = "Verify user.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignupVerifyResponse>> VerifyUserAsync(VerifyUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("forgotpassword")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Forgot password request.", Description = "Request link to reset forgotten password.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignupVerifyResponse>> ForgotPasswordRequestAsync(ForgotPasswordCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("verifyforgotpassword")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Verify forgot password request.", Description = "Verify forgot password request.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignupVerifyResponse>> VerifyForgotPasswordRequestAsync(VerifyForgotPasswordCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("setnewpassword")]
        [SwaggerOperation(Summary = "Set new password.", Description = "Set new password after forgot password request.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SignupVerifyResponse>> SetNewPasswordAsync(SetNewPasswordCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("refresh")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Refresh token.", Description = "Refresh token.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RefreshAsync(RefreshTokenCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
