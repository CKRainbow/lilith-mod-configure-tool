using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace LilithModConfigureTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            //LocalizeDictionary.Instance.Culture = new System.Globalization.CultureInfo("zh-CN");
        }
    }
}
