using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Veterinary.WEB.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            var Admin = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Orlando"),
                new Claim("LastName", "A"),
                new Claim(ClaimTypes.Name, "orlapez@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
        }
    }
}
