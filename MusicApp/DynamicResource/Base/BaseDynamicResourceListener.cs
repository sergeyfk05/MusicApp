using System;
using System.Windows;

namespace MusicApp.DynamicResource.Base
{
    /// <summary>
    /// Базовый класс для слушателей изменения культуры
    /// </summary>
    public abstract class BaseDynamicResourceListener<T> : IWeakEventListener, IDisposable
    {
        protected BaseDynamicResourceListener(IEventManager eventManager, IDynamicResourceManager manager)
        {
            _eventManager = eventManager;
            _manager = manager;
            _eventManager.AddListener(_manager.Instance, this);
        }
        private IEventManager _eventManager;
        private IDynamicResourceManager _manager;

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(CultureChangedDynamicResourceEventManager<T>))
            {
                OnCultureChanged();
                return true;
            }
            return false;
        }

        protected abstract void OnCultureChanged();

        public void Dispose()
        {
            _eventManager.RemoveListener(_manager.Instance, this);
            GC.SuppressFinalize(this);
        }
    }
}
