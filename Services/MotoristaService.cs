﻿using GoFast.UI.DTO;
using GoFast.UI.DTO.ViewModel;
using Newtonsoft.Json;
using System.Text;

namespace GoFast.UI.Services
{
    public class MotoristaService : IMotoristaService
    {
        //public readonly string uriBase = "https://localhost:7010/api/";
        private readonly string baseUrl = "https://localhost:7010/";
        private readonly HttpClient _httpClient;

        public MotoristaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MotoristaViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync(baseUrl + "api/Motorista/GetAll");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<MotoristaViewModel>>(content).ToList();

            return data;
        }

        public async Task<MotoristaViewModel> GetById(string id)
        {
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
            var response = await _httpClient.PostAsync(baseUrl + "api/Motorista/GetById?idMotorista=", body);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content.ReadAsStringAsync().Result.Substring(7,36);
            
            return "";
        }

        public async Task DeleteById(Guid id)
        {
            var response = await _httpClient.DeleteAsync(baseUrl + "Motorista/Delete?idMotorista=" + id.ToString());
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(MotoristaViewModel motoristaDTO)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(motoristaDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(baseUrl + "Motorista/Update", body);
            response.EnsureSuccessStatusCode();
        }
    }
}
