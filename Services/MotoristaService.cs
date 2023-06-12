using GoFast.UI.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GoFast.UI.Services
{
    public class MotoristaService : IMotoristaService
    {
        public readonly string uriBase = "https://localhost:7010/v1/";
        private readonly HttpClient _httpClient;

        public MotoristaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MotoristaDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync(uriBase + "GetAll");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<MotoristaDTO>>(content).ToList();

            return data;
        }

        public async Task<MotoristaDTO> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync(uriBase + "GetById?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();

            return new MotoristaDTO();
        }

        public async Task Create(MotoristaDTO motoristaDTO)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(motoristaDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uriBase + "Create", body);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteById(Guid id)
        {
            var response = await _httpClient.DeleteAsync(uriBase + "DeleteById?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(MotoristaDTO motoristaDTO)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(motoristaDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(uriBase + "Update", body);
            response.EnsureSuccessStatusCode();
        }
    }
}
