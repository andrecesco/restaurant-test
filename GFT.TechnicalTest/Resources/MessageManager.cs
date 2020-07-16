using System.Globalization;
using System.Resources;

namespace GFT.TechnicalTest.Resources
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

        public static string GetTag(string key)
        {
            return GetMessage(QueryTag.ResourceManager, key);
        }

        private static string GetMessage(ResourceManager manager, string key)
        {
            return manager.GetString(key, cultureInfo);
        }
    }
}
