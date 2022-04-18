
using CachingExample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Create a singleton cache
using var host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) 
    => services.AddMemoryCache()
    .AddSingleton<DisplayManager>()
    .AddSingleton<DataService>()).Build();


static void Main(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var displayManager = provider.GetRequiredService<DisplayManager>();
    var task = Task.Run(() =>
    {
        displayManager.InitializeCached();
    });
    
    task.Wait();
}

Main(host.Services);
