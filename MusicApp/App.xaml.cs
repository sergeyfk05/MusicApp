﻿using MusicApp.DynamicResource.Themes;
using MusicApp.DynamicResource.Languages;
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

            /*var a = new MusicApp.Models.ThemeInfo("1");
            a = new MusicApp.Models.ThemeInfo("1");
            a = new MusicApp.Models.ThemeInfo("1");*/

            LanguagesManager.Instance.Provider = new ResxLanguagesProvider();
            ThemeManager.Instance.Provider = new ResxThemeChangerProvider("ru");
        }
    }
}
