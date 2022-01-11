
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Noteboard.DataAccess.Azure.Storage;
using Noteboard.DataAccess.Azure.Storage.Models;

namespace Noteboard.DataAccess.Azure
{
    public static class Bootstrapper
    {
        public static void BootstrapDataAccessAzure(this IServiceCollection container, IConfiguration configuration)
        {
            container.AddScoped<ITableStorageManager<NoteTableEntity>, TableStorageManager<NoteTableEntity>>();
        }

        public static IServiceCollection ConfigureDataAccessAzure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.Configure<StorageTableOptions>(options => options.Configure(configuration));
        }

        private static void Configure(this StorageTableOptions tableOptions, IConfiguration configuration)
        {
            var section = configuration.GetSection("Azure:StorageTable");
            section.Bind(tableOptions);
        }
    }
}
