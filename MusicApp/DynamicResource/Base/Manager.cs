using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DynamicResource.Base
{
    public abstract class Manager
    {
        public abstract object GetResource(string key);

        public abstract Manager InstanceStock { get; }

        public event EventHandler CultureChanged = (sender, e) => { };

        protected void OnCultureChanged()
        {
            CultureChanged(this, EventArgs.Empty);
        }

    }
    public abstract class Manager<T> : Manager
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

        public Provider<T> Provider { get; set; }

        public abstract Manager<T> Instance { get; }

    }
}
