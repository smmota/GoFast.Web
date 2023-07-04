using GoFast.UI.DTO;
using GoFast.UI.DTO.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace GoFast.UI.Services
{
    public class MotoristaService : IMotoristaService
    {
        //public readonly string uriBase = "https://localhost:7010/api/";
        private readonly string uriBase = "https://apigofast2.azurewebsites.net/api/";
        private readonly HttpClient _httpClient;
        private IAuthService _authService;

        public MotoristaService(HttpClient httpClient, IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<MotoristaViewModel>> GetAll()
        {
            var token = await _authService.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("bearer", token);

                var response = await _httpClient.GetAsync(uriBase + "Motorista/GetAll");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<List<MotoristaViewModel>>(content).ToList();

                return data;
            }

            return null;
        }

        public async Task<MotoristaViewModel> GetById(string id)
        {
            var token = await _authService.GetTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("bearer", token);

            var response = await _httpClient.GetAsync(uriBase + "Motorista/GetById?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<MotoristaViewModel>(content);

                return data;
            }

            return new MotoristaViewModel();
        }

        public async Task<String> Create(MotoristaDTO motoristaDTO)
        {
            var token = await _authService.GetTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("bearer", token);

            HttpContent body = new StringContent(JsonConvert.SerializeObject(motoristaDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uriBase + "Motorista/Create", body);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content.ReadAsStringAsync().Result.Substring(7,36);
            
            return "";
        }

        public async Task DeleteById(Guid id)
        {
            var token = await _authService.GetTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("bearer", token);

            var response = await _httpClient.DeleteAsync(uriBase + "Motorista/Delete?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(MotoristaViewModel motoristaDTO)
        {
            var token = await _authService.GetTokenAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("bearer", token);

            HttpContent body = new StringContent(JsonConvert.SerializeObject(motoristaDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(uriBase + "Motorista/Update", body);
            response.EnsureSuccessStatusCode();
        }
    }
}
