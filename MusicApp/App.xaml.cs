﻿using MusicApp.Localization;
using MusicApp.ThemeChanger;
using System.Windows;

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

            var a = new MusicApp.Models.ThemeInfo("1");
            a = new MusicApp.Models.ThemeInfo("1");
            a = new MusicApp.Models.ThemeInfo("1");

            LocalizationManager.Instance.LocalizationProvider = new ResxLocalizationProvider();
            ThemeManager.Instance.ThemeChangerProvider = new ResxThemeChangerProvider("light");
        }
    }
}
