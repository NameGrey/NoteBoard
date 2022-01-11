using System.Reflection;
using Mapster;

namespace Noteboard.UI.Maps
{
    public static class Bootstrapper
    {
        public static void InitializeMaps()
        {
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly());
            TypeAdapterConfig.GlobalSettings.Scan(typeof(Business.Bootstrapper).Assembly);
        }
    }
}
