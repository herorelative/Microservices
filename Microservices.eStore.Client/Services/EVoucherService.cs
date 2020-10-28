using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
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
            var content = await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                //show error
            }
            return await JsonSerializer.DeserializeAsync<eVoucherVM>(content);
        }

        public async Task DeleteAnEvoucher(Guid Id)
        {
            var deleteResult = await _httpClient.DeleteAsync($"https://localhost:44365/api/evouchers/{Id}");
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }

        public async Task<IEnumerable<eVoucherVM>> GetAllEvouchers()
        { 
            return await JsonSerializer.DeserializeAsync<IEnumerable<eVoucherVM>>(
                await _httpClient.GetStreamAsync($"https://localhost:44365/api/evouchers"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<eVoucherVM> GetAnEvoucher(Guid Id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44365/api/evouchers/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<eVoucherVM>(content,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateAnEvoucher(Guid Id,eVoucherUpdateVM evoucher)
        {
            var evoucherJson = new StringContent(
                JsonSerializer.Serialize(evoucher), Encoding.UTF8, "application/json");
            var putResult = await _httpClient.PutAsync($"https://localhost:44365/api/evouchers/{Id}", evoucherJson);
            var putContent = await putResult.Content.ReadAsStringAsync();

            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }
        }

        public async Task ChangeActiveStatusEvoucher(Guid Id)
        {
            var patchResult = await _httpClient.PatchAsync($"https://localhost:44365/api/evouchers/{Id}",null);
            var patchContent = await patchResult.Content.ReadAsStringAsync();

            if (!patchResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(patchContent);
            }
        }

        public async Task<string> UploadEvoucherImage(MultipartFormDataContent content)
        {
            var postResult= await _httpClient.PostAsync("https://localhost:44365/api/uploads", content);

            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var ImageUrl = Path.Combine("https://localhost:44365/", postContent);
                return ImageUrl;
            }
        }
    }
}