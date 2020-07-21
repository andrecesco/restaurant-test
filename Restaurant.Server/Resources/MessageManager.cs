using System.Globalization;
using System.Resources;

namespace Restaurant.Resources
{
    public static class MessageManager
    {
        #region Static Properties
        private static readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;
        #endregion

        public static string GetException(string key)
        {
            return GetMessage(Exceptions.ResourceManager, key);
        }

        private static string GetMessage(ResourceManager manager, string key)
        {
            return manager.GetString(key, cultureInfo);
        }
    }
}
