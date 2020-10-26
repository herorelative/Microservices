using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Services
{
    public class EVoucherService : IEVoucherService
    {
        private readonly HttpClient _httpClient;

        public EVoucherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<eVoucherVM> AddEvoucher(eVoucherCreateVM evoucher)
        {
            var evoucherJson = new StringContent(
                JsonSerializer.Serialize(evoucher), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44365/api/evouchers", evoucherJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<eVoucherVM>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task<IEnumerable<eVoucherVM>> GetAllEvouchers()
        { 
            return await JsonSerializer.DeserializeAsync<IEnumerable<eVoucherVM>>(
                await _httpClient.GetStreamAsync($"https://localhost:44365/api/evouchers"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<eVoucherVM> GetAnEvoucher(Guid Id)
        {
            return await JsonSerializer.DeserializeAsync<eVoucherVM>(
                await _httpClient.GetStreamAsync($"https://localhost:44365/api/evouchers/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateAnEvoucher(Guid Id,eVoucherUpdateVM evoucher)
        {
            var evoucherJson = new StringContent(
                JsonSerializer.Serialize(evoucher), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"https://localhost:44365/api/evouchers/{Id}", evoucherJson);
        }
    }
}