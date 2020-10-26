using Blazored.LocalStorage;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegisterResult> Register(UserRegisterVM registerModel)
        {
            var registerJson = new StringContent(JsonSerializer.Serialize(registerModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44365/api/accounts", registerJson);
            
            return await JsonSerializer.DeserializeAsync<RegisterResult>(await response.Content.ReadAsStreamAsync()); ;
        }

        public async Task<LoginResult> Login(LoginVM loginModel)
        {
            var loginJson = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44365/api/Login", loginJson);
            var loginResult = JsonSerializer.Deserialize<LoginResult>(
                await response.Content.ReadAsStringAsync(), 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            ((ApiAuthenticationStateProviderService)_authenticationStateProvider)
                .MarkAsAuthenticated(loginModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("bearer", loginResult.Token);

            return new LoginResult { Success = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProviderService)_authenticationStateProvider).MarkAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}