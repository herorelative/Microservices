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
            await _localStorage.SetItemAsync("refreshToken", loginResult.RefreshToken);

            ((ApiAuthenticationStateProviderService)_authenticationStateProvider)
                .MarkAsAuthenticated(loginResult.Token);

            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("bearer", loginResult.Token);

            return new LoginResult { Success = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("refreshToken");

            ((ApiAuthenticationStateProviderService)_authenticationStateProvider).MarkAsLoggedOut();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string> RefreshToken()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
            var tokenDto = JsonSerializer.Serialize(new RefreshTokenVM { Token = token, RefreshToken = refreshToken });
            var bodyContent = new StringContent(tokenDto, Encoding.UTF8, "application/json");
            var refreshResult = await _httpClient.PostAsync("https://localhost:44365/api/tokens/refresh", bodyContent);
            var refreshContent = await refreshResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResult>(refreshContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (!refreshResult.IsSuccessStatusCode)
            {
                await Logout();
                throw new ApplicationException("Something went wrong during the refresh token action");
            }
            await _localStorage.SetItemAsync("authToken", result.Token);
            await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return result.Token;
        }
    }
}