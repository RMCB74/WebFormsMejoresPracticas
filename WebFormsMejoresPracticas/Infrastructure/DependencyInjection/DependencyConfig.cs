

using Microsoft.Extensions.DependencyInjection;

using Serilog;

using System.Configuration;
using WebFormsMejoresPracticas.Infrastructure.Database;
using WebFormsMejoresPracticas.Repositories;
using WebFormsMejoresPracticas.Services;


namespace WebFormsMejoresPracticas.Infrastructure.DependencyInjection
{
    public static class DependencyConfig
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            //services.AddLogging(builder =>
            //{
            //    builder.ClearProviders();
            //    builder.AddSerilog();
            //});


            services.AddLogging(builder =>
            {
                builder.AddSerilog();
            });

            var connectionString =
                ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

            services.AddSingleton<IDbConnectionFactory>(
                new SqlConnectionFactory(connectionString));

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IClienteService, ClienteService>();


            services.AddScoped<ITipoContactoRepository, TipoContactoRepository>();

            services.AddScoped<ITipoContactoService, TipoContactoService>();


            services.AddScoped<IContactoRepository, ContactoRepository>();
            services.AddScoped<IContactoService, ContactoService>();


            return services.BuildServiceProvider();
        }
    }
}