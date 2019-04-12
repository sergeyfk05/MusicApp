using System.ComponentModel;

namespace MusicApp.DynamicResource.Base
{
    /// <summary>
    /// Слушатель изменения культуры при локализации по ключу
    /// </summary>
    public class KeyDynamicResourceListener<T> : BaseDynamicResourceListener<T>, INotifyPropertyChanged where T: BaseManager
    {
        public KeyDynamicResourceListener(string key, object[] args, IEventManager eventManager, BaseManager manager) 
            :base(eventManager, manager)
        {
            _manager = manager;
            Key = key;
            Args = args;
        }

        private BaseManager _manager;
        private string Key { get; }

        private object[] Args { get; }

        public object Value
        {
            get
            {
                var value = _manager.InstanceStock.GetResource(Key);
                if (value is string && Args != null)
                    value = string.Format((string)value, Args);
                return value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnCultureChanged()
        {
            // Уведомляем привязку об изменении строки
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }
}
