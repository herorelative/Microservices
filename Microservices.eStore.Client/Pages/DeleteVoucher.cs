using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class DeleteVoucher : ComponentBase, IDisposable
    {
        [Parameter]
        public Guid id { get; set; }

        public eVoucherVM ModelFromRepo = new eVoucherVM();

        [Inject]
        public IEVoucherService EvoucherService { get; set; }
        [Inject]
        public NavigationManager NaviManager { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();

            ModelFromRepo = await EvoucherService.GetAnEvoucher(id);
            if (ModelFromRepo == null)
            {
                //show error message
            }
        }

        public async Task HandleDelete()
        {
            await EvoucherService.DeleteAnEvoucher(ModelFromRepo.Id);
            NaviManager.NavigateTo("/evouchers");
            //if (addedVoucher != null)
            //{
            //    //created
            //}
            //else
            //{
            //    //something went wrong
            //}
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}
