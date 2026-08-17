using Microsoft.Extensions.DependencyInjection;
using WebFormsSoapService.Interfaces;
using WebFormsSoapService.Repositories;


using WebFormsSoapService.Services;

namespace WebFormsSoapService.DependencyInjection
{
    public static class DependencyConfig
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IClienteService, ClienteServiceImpl>();

            services.AddScoped<IContactoRepository, ContactoRepository>();
            services.AddScoped<ITipoContactoRepository, TipoContactoRepository>();

            services.AddScoped<IContactoService, ContactoServiceImpl>();
            services.AddScoped<ITipoContactoService, TipoContactoServiceImpl>();


            return services.BuildServiceProvider();
        }
    }
}
