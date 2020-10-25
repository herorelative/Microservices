using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using Microservices.eStore.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace Microservices.eStore.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProviderService>();

            builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
                client.BaseAddress = new Uri("https://localhost:44365")
            );
            builder.Services.AddHttpClient<IPaymentMethodService, PaymentMethodService>(client =>
                client.BaseAddress = new Uri("https://localhost:44365")
            );

            await builder.Build().RunAsync();
        }
    }
}
