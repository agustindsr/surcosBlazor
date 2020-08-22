using Blazor.FileReader;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using SurcosBlazor.Client.Auth;
using SurcosBlazor.Client.Repositorio;
using SurcosBlazor.Client.Validators;

namespace SurcosBlazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddScoped<JWTAuthenticationProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationProvider>(provider => provider.GetRequiredService<JWTAuthenticationProvider>());
            services.AddScoped<ILoginService, JWTAuthenticationProvider>(provider => provider.GetRequiredService<JWTAuthenticationProvider>());
            services.AddScoped<IRepositorio, SurcosBlazor.Client.Repositorio.Repositorio>();
            services.AddScoped<MovimientoCajaValidator>();
            services.AddScoped<DetalleOrdenProduccionValidator>();

            services.AddFileReaderService(x => x.InitializeOnFirstCall = true);
            services.AddBlazoredToast();

        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
