namespace BugTracker.Identity.UseCases.GetUserToken
{
	using System;
	using System.Collections.Generic;
	using System.IdentityModel.Tokens.Jwt;
	using System.Linq;
	using System.Security.Claims;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using BugTracker.Identity.Models;
	using BugTracker.SharedKernel.Abstract;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.Configuration;
	using Microsoft.IdentityModel.Tokens;

	public class GetUserTokenHandler : IQueryHandler<GetUserToken, string>
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;

		public GetUserTokenHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
		}

		public async Task<string> Handle(GetUserToken request, CancellationToken cancellationToken)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var jwtOptions = _configuration.GetSection("JwtConfig");
			var secret = jwtOptions.GetValue<string>("secret");
			var user = await _userManager.FindByNameAsync(request.UserName);
			var roles = await _userManager.GetRolesAsync(user);
			var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.UserName) };

			claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

			var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Audience = jwtOptions.GetValue<string>("audience"),
				Issuer = jwtOptions.GetValue<string>("issuer"),
				Subject = new ClaimsIdentity(claims.ToArray()),
				Expires = DateTime.UtcNow.AddMinutes(jwtOptions.GetValue<int>("expirationInMinutes")),
				SigningCredentials = new SigningCredentials(securityKey,
					SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}