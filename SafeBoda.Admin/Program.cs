using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SafeBoda.Admin;
using SafeBoda.Admin.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:5248/") });

builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TripsClient>();
builder.Services.AddScoped<DriversClient>();
builder.Services.AddScoped<SystemClient>();

await builder.Build().RunAsync();
