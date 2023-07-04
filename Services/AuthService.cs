using GoFast.UI.DTO;
using NPOI.OpenXmlFormats.Dml;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace GoFast.UI.Services
{
    public class AuthService : IAuthService
    {
        //private readonly string baseUrl = "https://apigofast.azurewebsites.net/";
        //private readonly string baseUrl = "https://localhost:7010/";
        private readonly string baseUrl = "https://apigofast2.azurewebsites.net/";

        private HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<LoginResultDTO> Login(LoginDTO loginDTO)
        {
            var loginAsJson = JsonSerializer.Serialize(loginDTO);
            var response = await _httpClient.PostAsync(baseUrl + "api/Usuario/Login",
                new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

            var loginResult = JsonSerializer.Deserialize<LoginResultDTO>(await
                response.Content.ReadAsStringAsync(), new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });

            await _localStorage.SetItemAsync("authToken", loginResult.Token);

            //((ApiAuthenticationStateProvider)_authenticationStateProvider)
            //    .MarkUserAsAuthenticated(loginDTO.Email);

            _httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            //((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResultDTO> Register(RegisterDTO registerDTO)
        {
            var messageResult = await _httpClient.PostAsJsonAsync(baseUrl + "api/Usuario/Create", registerDTO);
            return await messageResult.Content.ReadFromJsonAsync<RegisterResultDTO>();
        }

        public async Task<string> GetTokenAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return token;
        }
    }
}
