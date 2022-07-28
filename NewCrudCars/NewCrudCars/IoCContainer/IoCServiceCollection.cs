using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewCrudCars.Client;
using NewCrudCars.Repository;
using NewCrudCars.Services;

namespace NewCrudCars.IoCContainer
{
    public static class IoCServiceCollection
    {
        public static ContainerBuilder BuildContext(this IServiceCollection services, IConfiguration Configuration)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);
            return BuildContext(builder, Configuration);
        }

        public static ContainerBuilder BuildContext(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.Register((context, parameters) => NpgsqlClient.Create(
                    Environment.GetEnvironmentVariable("POSTGRESS_CONECTION_STRING")
                ))
                .SingleInstance();
            builder.Register((context, parameters) => new CarRepository(
                    context.Resolve<NpgsqlClient>()
                ))
                .SingleInstance();
            builder.Register((context, parameters) => new CarService(
                    context.Resolve<CarRepository>()
                ))
                .SingleInstance();
            return builder;
        }
    }
}