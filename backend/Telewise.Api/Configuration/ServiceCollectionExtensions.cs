using Telewise.Api.Features.CRM.Repositories;
using Telewise.Api.Features.CRM.Services;
using Telewise.Api.Features.OAuth.Clients;
using Telewise.Api.Features.OAuth.Repositories;
using Telewise.Api.Features.OAuth.Services;
using Telewise.Api.Features.Settings.Services.Implementations;
using Telewise.Api.Features.Settings.Services.Interfaces;
using Telewise.Api.Infrastructure.Mongo;
using Telewise.Api.Infrastructure.Repositories;
using Telewise.Api.Features.Notifications.Repositories;
using Telewise.Api.Features.Notifications.Services;

namespace Telewise.Api.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelewiseServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<MongoDbOptions>(
            configuration.GetSection(MongoDbOptions.SectionName));

        services.Configure<ZohoOptions>(
            configuration.GetSection(ZohoOptions.SectionName));

        services.Configure<NotificationOptions>(
            configuration.GetSection(NotificationOptions.SectionName));

        // MongoDB
        services.AddSingleton<MongoDbContext>();

        // Settings
        services.AddScoped<ISettingsRepository, SettingsRepository>();
        services.AddScoped<ISettingsService, SettingsService>();

        // OAuth
        services.AddHttpClient<ZohoOAuthClient>();
        services.AddScoped<IOAuthService, OAuthService>();
        services.AddScoped<IOAuthRepository, OAuthRepository>();

        // CRM
        services.AddScoped<ICrmEventRepository, CrmEventRepository>();
        services.AddScoped<ICrmEventService, CrmEventService>();

        // Notifications
        services.AddHttpClient<IZohoFlowService, ZohoFlowService>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<INotificationService, NotificationService>();

        // Zoho Flow
        services.AddHttpClient<IZohoFlowService, ZohoFlowService>();
    
        return services;
    }
}