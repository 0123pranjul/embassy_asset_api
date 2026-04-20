using EmbassyAassetManagementAPI.Interface;
using EmbassyAassetManagementAPI.Repository;

namespace EmbassyAassetManagementAPI.Service
{
    public static class ExcelServices
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<Idata, DataClass>();
            services.AddScoped<IVehicalUserDetails, VehicalUserDetails>();
            services.AddScoped<IDevice, DeviceRepo>();
        }
    }
}
