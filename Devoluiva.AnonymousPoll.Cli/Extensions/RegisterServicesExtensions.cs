using Devoluiva.AnonymousPoll.Cli.Processor;
using Devoluiva.AnonymousPoll.Cli.Providers;
using Devoluiva.AnonymousPoll.Library.Implementation.Formatters;
using Devoluiva.AnonymousPoll.Library.Interfaces.Formatters;
using Devoluiva.AnonymousPoll.Library.Interfaces.Processor;
using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Devoluiva.AnonymousPoll.Cli.Extensions
{
    public static class RegisterServicesExtensions
    {
        public static IHostBuilder ConfigureCliServices(this IHostBuilder builder)
        {
            return builder.ConfigureServices((_, services) =>
            {
                services.AddTransient<IInputProvider, InputProvider>();
                services.AddTransient<IStudentProvider, StudentProvider>();
                services.AddTransient<ISurveyProcesor, SurveyProcesor>();
                services.AddTransient<IOutputFormatter, OutputFormatter>();
                services.AddSingleton<App>();
            });
        }
    }
}
