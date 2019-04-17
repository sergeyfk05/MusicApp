using MusicApp.DynamicResource.Themes;
using MusicApp.DynamicResource.Languages;
using System.Windows;
using System.Linq;

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

            //реализовать выбор культуры из сохранений
            LanguagesManager.StaticInstance.Provider = new XMLLanguageChangerProvider("ru");
            //LanguagesManager.StaticInstance.CurrentCulture = LanguagesManager.StaticInstance.Provider.Cultures.First(x => x.Name == "en");
            ThemeManager.StaticInstance.Provider = new XMLThemeChangerProvider("white");
            ThemeManager.StaticInstance.CurrentCulture = ThemeManager.StaticInstance.Cultures.First(x => x.Name == "dark");
        }
    }
}
