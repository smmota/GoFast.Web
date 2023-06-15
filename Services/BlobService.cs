using GoFast.UI.DTO;
using Newtonsoft.Json;
using System.Text;

namespace GoFast.UI.Services
{
    public class BlobService : IBlobService
    {
        public readonly string uriBase = "https://localhost:7010/v1/";
        private readonly HttpClient _httpClient;

        public BlobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Create(string base64)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(base64), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uriBase + "api/Imagem/Upload", body);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content.ReadAsStringAsync().Result.Substring(7, 36);

            return "";
        }

        public async Task DeleteById(Guid id)
        {
            var response = await _httpClient.DeleteAsync(uriBase + "DeleteById?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();
        }

        public async Task<BlobDTO> GetById(string id)
        {
            var response = await _httpClient.GetAsync(uriBase + "GetMotoristaById?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<BlobDTO>(content);

                return data;
            }

            return new BlobDTO();
        }
    }
}
