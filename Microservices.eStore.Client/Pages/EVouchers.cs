using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class EVouchers : ComponentBase, IDisposable
    {
        private IEnumerable<eVoucherVM> evouchers { get; set; } = new List<eVoucherVM>();

        [Inject]
        public IEVoucherService EVoucherService { get; set; }
        
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Interceptor.RegisterEvent();
            evouchers = (await EVoucherService.GetAllEvouchers()).ToList();
        }
        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}
