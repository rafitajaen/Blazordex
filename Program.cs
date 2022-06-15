using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazordex;
using Blazordex.Clients;
using Blazordex.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var pokeApiOptions = builder.Configuration
                        .GetSection(PokeApiOptions.Name)
                        .Get<PokeApiOptions>();

builder.Services.AddHttpClient<PokeClient>(options =>
{
    options.BaseAddress = pokeApiOptions.BaseAddress;
});

await builder.Build().RunAsync();
