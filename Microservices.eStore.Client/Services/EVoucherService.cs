using Microservices.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<IEnumerable<eVoucherVM>> GetAllEvouchers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<eVoucherVM>>(
                await _httpClient.GetStreamAsync($"api/evouchers"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<eVoucherVM> GetAnEvoucher(Guid Id)
        {
            return await JsonSerializer.DeserializeAsync<eVoucherVM>(
                await _httpClient.GetStreamAsync($"api/evouchers/{Id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}