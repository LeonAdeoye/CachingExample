using BenchmarkNamespace;
using CachingExample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecordNamespace;

// Configure log4net to point to app.config
[assembly: log4net.Config.XmlConfigurator(Watch = true)]


using var host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) 
    => services.AddMemoryCache()
    .AddSingleton<DisplayManager>().AddHttpClient()
    .AddSingleton<DataService>()).Build();

static async Task Main(IServiceProvider services)
{
    // Declare, assign, and start the antecedent task.
    Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

    // Execute the continuation when the antecedent finishes.
    await taskA.ContinueWith(antecedent => Console.WriteLine($"Today is {antecedent.Result}."));

    using IServiceScope serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var displayManager = provider.GetRequiredService<DisplayManager>();

    var firstTask = Task.Run(() => displayManager.InitializeCached());
    await firstTask.ContinueWith((antecedent) => displayManager.InitializeCached());
}

await Main(host.Services);

BenchmarkDemo.Main();

RecordExample.Main();


