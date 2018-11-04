using System.Windows.Data;

namespace MusicApp.ThemeChanger
{
    /// <summary>
    /// Слушатель изменения культуры при локализации по привязке
    /// </summary>
    public class BindingThemeChangerListener : BaseThemeChangerListener
    {
        private BindingExpressionBase BindingExpression { get; set; }

        public void SetBinding(BindingExpressionBase bindingExpression)
        {
            BindingExpression = bindingExpression;
        }

        protected override void OnThemeChanged()
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
