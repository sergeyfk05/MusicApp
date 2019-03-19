using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DynamicResource.Base
{
    public abstract class BaseManager
    {
        public abstract object GetResource(string key);

        public abstract BaseManager InstanceStock { get; }

        public event EventHandler CultureChanged;

        protected void OnCultureChanged()
        {
            CultureChanged?.Invoke(this, EventArgs.Empty);
        }

    }
    public abstract class BaseManager<T> : BaseManager
    {
        public T CurrentCulture
        {
            get
            {
                if (Provider == null)
                    throw new NullReferenceException("Provider is null");

                return Provider.CurrentCulture;
            }
            set
            {
                if (Provider == null)
                    throw new NullReferenceException("Provider is null");

                if (Equals(value, Provider.CurrentCulture))
                    return;

                Provider.CurrentCulture = value;
                OnCultureChanged();
            }
        }

        public IEnumerable<T> Cultures => Provider?.Cultures ?? Enumerable.Empty<T>();

        public BaseProvider<T> Provider { get; set; }

        public abstract BaseManager<T> Instance { get; }

    }
}
