namespace BugTracker.API.Endpoints.Identity
{
	using System.Threading.Tasks;
	using Ardalis.ApiEndpoints;
	using BugTracker.Identity.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Swashbuckle.AspNetCore.Annotations;

	public class Register : BaseAsyncEndpoint<RegisterRequest, RegisterResponse>
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public Register(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost("register")]
		[SwaggerOperation(
			Summary = "Register a user",
			Description = "Register a user",
			OperationId = "identity.register",
			Tags = new[] { "IdentityEndpoints" })
		]
		public override async Task<ActionResult<RegisterResponse>> HandleAsync([FromBody] RegisterRequest request)
		{
			var newUser = new ApplicationUser
			{
				Email = request.Email,
				UserName = request.Username,
				EmailConfirmed = true
			};

			var result = await _userManager.CreateAsync(newUser, request.Password);
			var response = new RegisterResponse(result.Succeeded);

			if (!result.Succeeded)
				return this.UnprocessableEntity(response);

			return this.Ok(response);
		}
	}
}