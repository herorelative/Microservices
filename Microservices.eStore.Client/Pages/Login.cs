using Microservices.eStore.Client.Services;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Pages
{
    public partial class Login : ComponentBase
    {
        public LoginVM loginModel = new LoginVM();
        public bool ShowErrors;
        public string Error = "";

        [Inject]
        private IAuthService AuthService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public async Task HandleLogin()
        {
            ShowErrors = false;

            var result = await AuthService.Login(loginModel);

            if (result.Success)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Error = result.Error;
                ShowErrors = true;
            }
        }
    }
}
