using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using RazorPagesSettings.Data;

namespace subbedsub
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBrowserExtensionServices();
            builder.Services.AddDbContext<RazorPagesSettingsContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesSettingsContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));
            await builder.Build().RunAsync();
        }
    }
}
