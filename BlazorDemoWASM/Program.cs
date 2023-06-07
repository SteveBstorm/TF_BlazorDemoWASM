using BlazorDemoWASM;
using BlazorDemoWASM.Pages.Tools;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7073/api/") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://bstormBlazorDemo.somee.com/api/") });

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, MyStateProvider>();

await builder.Build().RunAsync();
