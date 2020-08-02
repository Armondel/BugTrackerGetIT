namespace BugTracker.API.Endpoints.Tests
{
	using System.Threading.Tasks;
	using Ardalis.ApiEndpoints;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Swashbuckle.AspNetCore.Annotations;

	public class GetSampleAuthorized : BaseAsyncEndpoint<GetSampleAuthroizedRequest, GetSampleAuthorizedResponse>
	{
		[Authorize]
		[HttpGet("test/authorized")]
		[SwaggerOperation(
			Summary = "Get sample data for authorized user",
			OperationId = "test.authorized",
			Tags = new[] { "TestEndpoints" })]
		public override async Task<ActionResult<GetSampleAuthorizedResponse>> HandleAsync(
			GetSampleAuthroizedRequest request)
		{
			var response = new GetSampleAuthorizedResponse("You did it");
			return this.Ok(response);
		}
	}
}