using Application.Configurations.AutoMapperConfiguration;
using Application.Interfaces;
using Application.MessageBroker;
using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(c => {
            c.AddProfile(new MapperOrganizationProfile());
        });

        services.AddFastEndpoints();
        services.AddScoped<IMessageBrokerConnection, RabbitMQConnection>();
        return services;
    }
}
