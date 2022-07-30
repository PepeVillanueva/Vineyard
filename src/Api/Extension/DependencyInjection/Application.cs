using Microsoft.Extensions.DependencyInjection;
using Vineyard.Activity.Work.Application;

namespace Vineyard.Api.Extension.DependencyInjection
{
    public static class Application
    {
         public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IWorkCreator, WorkCreator>();

            return services;
        }
    }
}