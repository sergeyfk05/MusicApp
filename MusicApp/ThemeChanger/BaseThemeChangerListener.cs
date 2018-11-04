using System;
using System.Windows;

namespace MusicApp.ThemeChanger
{
    /// <summary>
    /// Базовый класс для слушателей изменения культуры
    /// </summary>
    public abstract class BaseThemeChangerListener : IWeakEventListener, IDisposable
    {
        protected BaseThemeChangerListener()
        {
            ThemeChangedEventManager.AddListener(ThemeManager.Instance, this);
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(ThemeChangedEventManager))
            {
                OnThemeChanged();
                return true;
            }
            return false;
        }

        protected abstract void OnThemeChanged();

        public void Dispose()
        {
            ThemeChangedEventManager.RemoveListener(ThemeManager.Instance, this);
            GC.SuppressFinalize(this);
        }
    }
}
