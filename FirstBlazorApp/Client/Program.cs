using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

//using Blazorise;
//using Blazorise.Bootstrap;
//using Blazorise.Icons.FontAwesome;

using BlazorStrap;
using BlazorStyled;
using Blazor.Extensions.Logging;

namespace FirstBlazorApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //builder.Services
            //  .AddBlazorise(options =>
            //  {
            //      options.ChangeTextOnKeyPress = true;
            //  })
            //  .AddBootstrapProviders()
            //  .AddFontAwesomeIcons();

            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazorStyled();
            builder.Services.AddBootstrapCss();

            //builder.Logging.SetMinimumLevel(LogLevel.Debug);
            //builder.Logging.ClearProviders();
            //builder.Logging.AddBrowserConsole();

            // Add Blazor.Extensions.Logging.BrowserConsoleLogger
            //builder.Services.AddLogging(builder => builder
            //    .AddBrowserConsole()
            //    .SetMinimumLevel(LogLevel.Trace)
            //);

            builder.Services.Configure<ILoggingBuilder>(logging =>
            {
                logging.ClearProviders();
                logging.AddBrowserConsole();
                logging.SetMinimumLevel(LogLevel.Debug);
            });

            var host = builder.Build();

            //host.Services
            //    .UseBootstrapProviders()
            //    .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
