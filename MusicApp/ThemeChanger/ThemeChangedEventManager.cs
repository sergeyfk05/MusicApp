using System;
using System.Windows;

namespace MusicApp.ThemeChanger
{
    public class ThemeChangedEventManager : WeakEventManager
    {
        private static ThemeChangedEventManager CurrentManager
        {
            get
            {
                var managerType = typeof(ThemeChangedEventManager);
                var manager = (ThemeChangedEventManager)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new ThemeChangedEventManager();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

        public static void AddListener(ThemeManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListener(ThemeManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnCultureChanged(object sender, EventArgs e)
        {
            DeliverEvent(sender, e);
        }

        protected override void StartListening(object source)
        {
            var manager = (ThemeManager)source;
            manager.ThemeChanged += OnCultureChanged;
        }

        protected override void StopListening(object source)
        {
            var manager = (ThemeManager)source;
            manager.ThemeChanged -= OnCultureChanged;
        }
    }
}
