using Microsoft.Extensions.Configuration;

namespace WizardForm.Extensions
{
    public static class SettingExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);
            var configurationValue = new T();
            configuration.GetSection(section).Bind(configurationValue);
            return configurationValue;
        }
    }
}