using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Noteboard.Business.Services;

namespace Noteboard.Business
{
    public static class Bootstrapper
    {
        public static void BootstrapBusiness(this IServiceCollection container, IConfiguration configuration)
        {
            container.AddScoped<INoteService, NoteService>();
        }
    }
}
