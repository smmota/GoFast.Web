using GoFast.UI.DTO;
using GoFast.UI.DTO.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using GoFast.UI.Services.Authentication;

namespace GoFast.UI.Services
{
    public class MotoristaService : IMotoristaService
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private IAuthService _authService;
        private HttpClient _httpClient;

        private readonly string baseUrl = "https://localhost:7010/";

        public MotoristaService(HttpClient httpClient,IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<MotoristaViewModel>> GetAll()
        {
            try
            {
                var token = await _authService.GetTokenAsync();

                //_httpClient.DefaultRequestHeaders.Authorization = new
                //    AuthenticationHeaderValue("bearer", token);

                //var url = baseUrl + "api/Motorista/GetAll";
                //var baseUri = new Uri(url);

                //_httpClient.BaseAddress = baseUri;

                var response = await _httpClient.GetAsync(baseUrl + "api/Motorista/GetAll");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<List<MotoristaViewModel>>(content).ToList();

                return data;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MotoristaViewModel> GetById(string id)
        {
            var token = await _authService.GetTokenAsync();

            var response = await _httpClient.GetAsync(baseUrl + "api/Motorista/GetById?idMotorista=" + id.ToString());
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
            HttpContent body = new StringContent(JsonConvert.SerializeObject(motoristaDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(baseUrl + "api/Motorista/Create", body);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content.ReadAsStringAsync().Result.Substring(7,36);
            
            return "";
        }

        public async Task DeleteById(Guid id)
        {
            var response = await _httpClient.DeleteAsync("api/Motorista/Delete?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(MotoristaViewModel motoristaDTO)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(motoristaDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(baseUrl + "api/Motorista/Update", body);
            response.EnsureSuccessStatusCode();
        }
    }
}
