using Infrastructure.Data;
using Infrastructure.Mappers;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WizardForm.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IWizardService, WizardService>();
            services.AddSingleton(configuration.GetSettings<EmailConfigSettings>());
            services.AddSingleton(AutoMapperConfig.Initialize());
            return services;
        }
    }
}