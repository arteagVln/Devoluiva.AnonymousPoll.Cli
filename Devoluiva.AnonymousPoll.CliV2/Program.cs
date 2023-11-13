using Devoluiva.AnonymousPoll.CliV2;
using Devoluiva.AnonymousPoll.CliV2.DBContext;
using Devoluiva.AnonymousPoll.CliV2.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

try
{
    using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureCliV2Services()
    .Build();

    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<StudentContext>();
    context.Database.EnsureCreated();
    DataGenerator.Initialize(services);

    services.GetRequiredService<App>().Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}