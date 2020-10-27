using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class EditVoucher : ComponentBase, IDisposable
    {

        [Parameter]
        public Guid id { get; set; }
        public string PaymentMethodId { get; set; }

        public eVoucherUpdateVM voucher = new eVoucherUpdateVM();
        public IEnumerable<PaymentMethodVM> Payments { get; set; } = new List<PaymentMethodVM>();
        
        [Inject]
        NavigationManager NaviManager { get; set; }

        [Inject]
        public HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public IEVoucherService EvoucherServ { get; set; }

        [Inject]
        IPaymentMethodService PaymentMethodServ { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Interceptor.RegisterEvent();
            Payments = (await PaymentMethodServ.GetAllPaymentMethods()).ToList();

            var modelFromRepo = await EvoucherServ.GetAnEvoucher(id);
            if (modelFromRepo == null)
            {
                //show error message
            }

            voucher.Title = modelFromRepo.Title;
            voucher.Description = modelFromRepo.Description;
            voucher.ExpireDate = modelFromRepo.ExpireDate;
            voucher.Quantity = modelFromRepo.Quantity;
            voucher.Amount = modelFromRepo.Amount;
            PaymentMethodId = modelFromRepo.PaymentMethodId.ToString();
            voucher.DiscountOnPaymentMethod = modelFromRepo.DiscountOnPaymentMethod;
            voucher.BuyType = modelFromRepo.BuyType;
        }

        protected async Task HandleSave()
        {
            voucher.PaymentMethodId = Guid.Parse(PaymentMethodId);
            await EvoucherServ.UpdateAnEvoucher(id, voucher);
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
