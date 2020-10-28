using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class EVouchers : IDisposable
    {
        private IEnumerable<eVoucherVM> evouchers { get; set; } = new List<eVoucherVM>();

        [Inject]
        public IEVoucherService EVoucherService { get; set; }

        [Inject]
        public NavigationManager NaviManager { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            await LoadData();
        }

        private async Task LoadData()
        {
            evouchers = (await EVoucherService.GetAllEvouchers()).ToList();
        }

        protected async Task ChangeStatus(Guid id)
        {
            await EVoucherService.ChangeActiveStatusEvoucher(id);
            await LoadData();
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
            Interceptor.DisposeEvent();
        }
    }
}
