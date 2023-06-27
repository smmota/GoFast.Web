using Blazored.LocalStorage;
using GoFast.UI.DTO;
using GoFast.UI.DTO.ViewModel;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoFast.UI.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        private string baseUrl = "https://localhost:7010/";

        public AuthService(HttpClient httpClient, 
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResultDTO> Login(LoginDTO loginDTO)
        {
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                LoginUser = loginDTO.Email,
                Senha = loginDTO.Senha
            };

            var loginAsJson = JsonSerializer.Serialize(loginViewModel);
            var response = await _httpClient.PostAsync(baseUrl + "api/Usuario/Login",
                new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<LoginResultViewModel>(await
                response.Content.ReadAsStringAsync(), new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });


            if (!response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<LoginResultDTO>(await
                response.Content.ReadAsStringAsync(), new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });
            }
            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            await _localStorage.SetItemAsync("tokenExpiration", loginResult.Expiration);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .MarkUserAsAuthenticated(loginDTO.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("bearer", loginResult.Token);

            return new LoginResultDTO()
            {
                Successful = true,
                Error = string.Empty,
                Token = loginResult.Token
            };
            //return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResultDTO> Register(RegisterDTO registerDTO)
        {
            var messageResult = await _httpClient.PostAsJsonAsync(baseUrl + "api/Usuario/Create", registerDTO);
            var result = await messageResult.Content.ReadFromJsonAsync<RegisterResultDTO>();
            return result;
        }

        public async Task<string> GetTokenAsync()
        {
            //Code Omitted for brevity 
            //This line of code is equivalent to the IJSRuntime.Invoke<string>("localstorage.getitem","authToken") 
            //change to use Blazore.LocalStorage.
            var token = await _localStorage.GetItemAsync<string>("authToken");
            return token;
        }
    }
}
