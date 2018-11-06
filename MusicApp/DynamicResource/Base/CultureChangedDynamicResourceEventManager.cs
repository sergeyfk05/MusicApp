using System;
using System.Windows;

namespace MusicApp.DynamicResource.Base
{
    public class CultureChangedDynamicResourceEventManager<T> : WeakEventManager, IEventManager
    {
        private static CultureChangedDynamicResourceEventManager<T> _eventmanager;
        public static CultureChangedDynamicResourceEventManager<T> Instance => _eventmanager ?? (_eventmanager = new CultureChangedDynamicResourceEventManager<T>());

        private static CultureChangedDynamicResourceEventManager<T> CurrentManager
        {
            get
            {
                var managerType = typeof(CultureChangedDynamicResourceEventManager<T>);
                var manager = (CultureChangedDynamicResourceEventManager<T>)GetCurrentManager(managerType);
                if (manager == null)
                {
                    manager = new CultureChangedDynamicResourceEventManager<T>();
                    SetCurrentManager(managerType, manager);
                }
                return manager;
            }
        }

        public static void AddListenerSt(IDynamicResourceManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }
        public void AddListener(IDynamicResourceManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }

        public static void RemoveListenerSt(IDynamicResourceManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }
        public void RemoveListener(IDynamicResourceManager source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }

        private void OnCultureChanged(object sender, EventArgs e)
        {
            DeliverEvent(sender, e);
        }

        protected override void StartListening(object source)
        {
            var manager = (IDynamicResourceManager)source;
            manager.CultureChanged += OnCultureChanged;
        }

        protected override void StopListening(object source)
        {
            var manager = (IDynamicResourceManager)source;
            manager.CultureChanged -= OnCultureChanged;
        }
    }
}
