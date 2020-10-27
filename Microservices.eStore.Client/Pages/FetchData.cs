using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class FetchData : ComponentBase
    {
        [Inject]
        public IPaymentMethodService PaymentMethods { get; set; }

        public IEnumerable<PaymentMethodVM> paymentmethods { get; set; } = new List<PaymentMethodVM>();

        protected override async Task OnInitializedAsync()
        {
            paymentmethods = (await PaymentMethods.GetAllPaymentMethods())
                .ToList();
        }
        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
