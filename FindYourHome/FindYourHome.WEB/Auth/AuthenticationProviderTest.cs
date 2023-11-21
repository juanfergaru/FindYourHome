using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FindYourHome.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim>
        {
            new Claim("FirstName", "Juan Fernando"),
            new Claim("LastName", "Galeano"),
            new Claim(ClaimTypes.Name, "jfgr@yopmail.com"),
            new Claim(ClaimTypes.Role, "User")
        },
authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}
