using Microservices.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly HttpClient _httpClient;

        public PaymentMethodService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PaymentMethodVM>> GetAllPaymentMethods()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PaymentMethodVM>>(
                await _httpClient.GetStreamAsync($"api/paymentmethods"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
