using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoFast.UI.Services.Authentication
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string savedToken = string.Empty;
            string expirationToken = string.Empty;

            try
            {
                savedToken = await _localStorage.GetItemAsync<string>("authToken");
                expirationToken = await _localStorage.GetItemAsync<string>("tokenExpiration");

                if (string.IsNullOrWhiteSpace(savedToken) || TokenExpirou(expirationToken))
                {
                    MarkUserAsLoggedOut();
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
            }
            catch { return null; }

            //return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            return new AuthenticationState(new ClaimsPrincipal(
                    new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
        }

        private bool TokenExpirou(string dataToken)
        {
            DateTime dataAtualUtc = DateTime.UtcNow;
            DateTime dataExpiracao =
                DateTime.ParseExact(dataToken, "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'", null,
                System.Globalization.DateTimeStyles.RoundtripKind);

            if (dataExpiracao < dataAtualUtc)
            {
                return true;
            }

            return false;
        }

        public void MarkUserAsAuthenticated(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email)
            }, "aouauth"));

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonynousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonynousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if(roles != null)
            {
                if(roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = System.Text.Json.JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: 
                    base64 += "=="; 
                    break;
                case 3:
                    base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }        
    }
}
