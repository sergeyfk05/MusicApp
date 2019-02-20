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
            LanguagesManager.Instance.Provider = new ResxLanguagesProvider("en");
            //LanguagesManager.Instance.CurrentCulture = LanguagesManager.Instance.Provider.Cultures.First(x => x.Name == "ru");
            ThemeManager.Instance.Provider = new ResxThemeChangerProvider("ru");
            ThemeManager.Instance.CurrentCulture = ThemeManager.Instance.Cultures.First(x => x.Name == "en");
        }
    }
}
