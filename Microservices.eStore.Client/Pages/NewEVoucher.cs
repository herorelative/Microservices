using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class NewEVoucher : ComponentBase, IDisposable
    {
        public string PaymentMethodId { get; set; }

        public eVoucherCreateVM voucher = new eVoucherCreateVM();
        public IEnumerable<PaymentMethodVM> Payments { get; set; } = new List<PaymentMethodVM>();

        [Inject]
        public IPaymentMethodService PaymentMethodServ { get; set; }
        [Inject]
        public IEVoucherService EvoucherServ { get; set; }
        [Inject]
        public NavigationManager NaviManager { get; set; }
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            Payments = (await PaymentMethodServ.GetAllPaymentMethods()).ToList();

            voucher.ExpireDate = DateTime.UtcNow.AddYears(1);
            voucher.Quantity = 1;
            voucher.Amount = 1;
            PaymentMethodId = Payments.FirstOrDefault().Id.ToString();
        }

        protected async Task HandleSave()
        {
            voucher.PaymentMethodId = Guid.Parse(PaymentMethodId);
            var addedVoucher = await EvoucherServ.AddEvoucher(voucher);
            if (addedVoucher != null)
            {
                //created
                NaviManager.NavigateTo("/evouchers");
            }
            else
            {
                //something went wrong
            }
        }

        private void UploadedImageUrl(string ImageUrl)
        {
            voucher.Image = ImageUrl;
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
}
