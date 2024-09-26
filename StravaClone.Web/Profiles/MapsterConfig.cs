using Mapster;

namespace StravaClone.Web.Profiles
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            // Register Mapster profiles or configurations
            TypeAdapterConfig.GlobalSettings.Scan(typeof(MapsterProfile).Assembly);
        }
    }
}
