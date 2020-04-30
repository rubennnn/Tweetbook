using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Tweetbook.Installers
{
    public class MVCInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                //x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TweetAPI", Description = "v1" });
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Esto es la documentación de la API", Version = "v1" });
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
    }
}
