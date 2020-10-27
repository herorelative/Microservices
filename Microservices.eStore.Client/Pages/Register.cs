using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public IAuthService AuthService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public UserRegisterVM RegisterModel = new UserRegisterVM();
        public bool ShowErrors;
        public IEnumerable<string> Errors;

        public async Task HandleRegistration()
        {
            ShowErrors = false;

            var result = await AuthService.Register(RegisterModel);

            if (result.Success)
            {
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                Errors = result.Errors;
                ShowErrors = true;
            }
        }
    }
}