using System.Reflection;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

namespace LilithModConfigureTool.Localization
{
    public static class LocalizationProvider
    {
        public static T GetLocalizaedValue<T>(string key)
        {
            return LocExtension.GetLocalizedValue<T>(Assembly.GetCallingAssembly().GetName().Name + ":Resources:" + key);
        }

        public static void ChangeLocalization(string culture)
        {
            if (culture == "") return;
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = new System.Globalization.CultureInfo(culture);
        }
    }
}
