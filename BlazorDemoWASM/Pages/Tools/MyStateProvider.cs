using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace BlazorDemoWASM.Pages.Tools
{
    public class MyStateProvider : AuthenticationStateProvider
    {
        
        private readonly IJSRuntime js;
        private readonly NavigationManager _nav;
        public MyStateProvider(IJSRuntime js, NavigationManager nav)
        {
            this.js = js;
            _nav = nav;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = "";
            try
            {
                token = await js.InvokeAsync<string>("localStorage.getItem", "token");
                Console.WriteLine("C'est ici le token ?");
                Console.WriteLine(token);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (!string.IsNullOrEmpty(token))
            {
                JwtSecurityToken jwt = new JwtSecurityToken(token);

                foreach(Claim c in jwt.Claims)
                {
                    Console.WriteLine(c);
                }

                ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "MyAuth");
                ClaimsPrincipal user = new ClaimsPrincipal(currentUser);

                return Task.FromResult(new AuthenticationState(user)).Result;
            }

            return Task.FromResult(
                new AuthenticationState(
                    new ClaimsPrincipal(
                        new ClaimsIdentity()))).Result;

            


        }

        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
