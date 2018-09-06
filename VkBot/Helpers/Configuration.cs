using System.Configuration;

namespace VkBot.Helpers
{
    public static class Configuration
    {
        public static ulong AppId => ulong.TryParse(ConfigurationManager.AppSettings["appId"], out ulong appId)
            ? appId
            : throw new SettingsPropertyNotFoundException("Парамер appId не задан или имеет неверный формат");

        public static string Login => ConfigurationManager.AppSettings["login"] ??
                                      throw new SettingsPropertyNotFoundException("Параметр login не задан");

        public static int PostCount => int.TryParse(ConfigurationManager.AppSettings["postCount"], out int postCount)
            ? postCount
            : throw new SettingsPropertyNotFoundException("Парамер postCount не задан или имеет неверный формат");

        public static string PostTo => ConfigurationManager.AppSettings["PostTo"] ??
                                      throw new SettingsPropertyNotFoundException("Параметр PostTo не задан");
    }
}