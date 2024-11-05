using DemoMauHocSinhBlazor;
using DemoMauHocSinhBlazor.Components;
using DemoMauHocSinhBlazor.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7284") });
builder.Services.AddScoped<HocSinhService>();
builder.Services.AddSingleton<SelectedHocSinhService>();
builder.Services.AddScoped<ToastComponent>();

await builder.Build().RunAsync();
