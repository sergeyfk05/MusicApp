using MusicApp.Localization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MusicApp.ThemeChanger;

namespace MusicApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LocalizationManager.Instance.LocalizationProvider = new ResxLocalizationProvider();
            ThemeManager.Instance.ThemeChangerProvider = new ResxThemeChangerProvider();
        }
    }
}
