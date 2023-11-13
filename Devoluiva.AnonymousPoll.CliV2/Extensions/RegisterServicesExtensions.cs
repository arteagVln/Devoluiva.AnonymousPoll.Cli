using Devoluiva.AnonymousPoll.Cli.Processor;
using Devoluiva.AnonymousPoll.CliV2.DBContext;
using Devoluiva.AnonymousPoll.CliV2.Formatters;
using Devoluiva.AnonymousPoll.CliV2.Providers;
using Devoluiva.AnonymousPoll.Library.Interfaces.Formatters;
using Devoluiva.AnonymousPoll.Library.Interfaces.Processor;
using Devoluiva.AnonymousPoll.Library.Interfaces.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace Devoluiva.AnonymousPoll.CliV2.Extensions
{
    public static class RegisterServicesExtensions
    {
        public static IHostBuilder ConfigureCliV2Services(this IHostBuilder builder)
        {
            return builder.ConfigureServices((_, services) =>
            {
                services.AddDbContext<StudentContext>(options => options.UseInMemoryDatabase("StudentDB"));
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                services.AddTransient<IInputProvider, InputProvider>();
                services.AddTransient<IStudentProvider, StudentProvider>();
                services.AddTransient<ISurveyProcesor, SurveyProcesor>();
                services.AddTransient<IOutputFormatter, BarOutputFormatter>();
                services.AddSingleton<App>();
            });
        }
    }
}
