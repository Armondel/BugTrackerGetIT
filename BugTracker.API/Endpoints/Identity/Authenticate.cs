namespace BugTracker.API.Endpoints.Identity
{
	using System.Threading.Tasks;
	using Ardalis.ApiEndpoints;
	using BugTracker.Identity.Models;
	using BugTracker.Identity.UseCases.GetUserToken;
	using MediatR;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Swashbuckle.AspNetCore.Annotations;

	public class Authenticate : BaseAsyncEndpoint<AuthenticateRequest, AuthenticateResponse>
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IMediator _mediator;

		public Authenticate(SignInManager<ApplicationUser> signInManager, IMediator mediator)
		{
			_signInManager = signInManager;
			_mediator = mediator;
		}


		[HttpPost("api/authenticate")]
		[SwaggerOperation(
			Summary = "Authenticates a user",
			Description = "Authenticates a user",
			OperationId = "identity.authenticate",
			Tags = new[] { "IdentityEndpoints" })
		]
		public override async Task<ActionResult<AuthenticateResponse>> HandleAsync(
			AuthenticateRequest request)
		{
			var response = new AuthenticateResponse();

			if (!request.RequestIsValid())
				return this.BadRequest("User data is missing");

			var result = await _signInManager.PasswordSignInAsync(
				request.Username,
				request.Password,
				false,
				true);

			response.Result = result.Succeeded;
			response.IsLockedOut = result.IsLockedOut;
			response.IsNotAllowed = result.IsNotAllowed;
			response.Username = request.Username;
			response.Token = await _mediator.Send(new GetUserToken(request.Username));

			return response;
		}
	}
}