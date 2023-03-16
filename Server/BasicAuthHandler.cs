﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Server.Repositories;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserRepository _userRepository;
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock, IUserRepository userRepository) :
       base(options, logger, encoder, clock)
    {
        _userRepository = userRepository;
    }

    protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authorizationHeader = Request.Headers["Authorization"].ToString();
        if (authorizationHeader != null && authorizationHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
        {
            var token = authorizationHeader.Substring("Basic ".Length).Trim();
            var credentialsAsEncodedString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialsAsEncodedString.Split(':');
            if (await _userRepository.Authenticate(credentials[0], credentials[1]))
            {
                var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Админ админов") };
                var identity = new ClaimsIdentity(claims, "Basic");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));
            }
        }
        Response.StatusCode = 401;
       
        return await Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
    }
}