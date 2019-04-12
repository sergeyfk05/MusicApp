using System.Windows.Data;

namespace MusicApp.DynamicResource.Base
{
    /// <summary>
    /// Слушатель изменения культуры при локализации по привязке
    /// </summary>
    public class BindingDynamicResourceListener<T> : BaseDynamicResourceListener<T> where T: BaseManager
    {
        public BindingDynamicResourceListener(IEventManager eventManager, BaseManager manager)
            :base (eventManager, manager)
        {

        }
        private BindingExpressionBase BindingExpression { get; set; }

        public void SetBinding(BindingExpressionBase bindingExpression)
        {
            BindingExpression = bindingExpression;
        }

        protected override void OnCultureChanged()
        {
            try
            {
                // Обновляем результат выражения привязки
                // При этом конвертер вызывается повторно уже для новой культуры
                BindingExpression?.UpdateTarget();
            }
            catch
            {
                // ignored
            }
        }
    }
}
