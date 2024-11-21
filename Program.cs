using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace SchedulerWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5120") });
            builder.Services.AddSingleton<staffschedulerlibrary.Models.Shift>();
            builder.Services.AddSingleton<DatabaseLogic.DatabaseManager>();
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }

}
