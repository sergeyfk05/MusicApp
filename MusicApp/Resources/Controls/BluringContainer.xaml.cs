using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicApp.Resources.Controls
{
    /// <summary>
    /// Interaction logic for BluringContainer.xaml
    /// </summary>
    public partial class BluringContainer : UserControl
    {
        public BluringContainer()
        {
            InitializeComponent();
        }


        #region properties

        /// <summary>
        /// Свойво, отображающее состояние эффекта.
        /// </summary>
        public bool IsBlured
        {
            get { return (bool)GetValue(IsBluredProperty); }
            set { SetValue(IsBluredProperty, value); }
        }
        public static readonly DependencyProperty IsBluredProperty =
            DependencyProperty.Register("IsBlured", typeof(bool), typeof(BluringContainer), new PropertyMetadata(false, new PropertyChangedCallback(OnIsBluredChanged)));

        #endregion

        #region routed events

        /// <summary>
        /// Событие, вызываемое при блюринге окна.
        /// </summary>
        public static readonly RoutedEvent BluredEvent =
            EventManager.RegisterRoutedEvent("Blured", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BluringContainer));
        public event RoutedEventHandler Blured
        {
            add { AddHandler(BluredEvent, value); }
            remove { RemoveHandler(BluredEvent, value); }
        }
        private void OnBlured()
        {
            RaiseEvent(new RoutedEventArgs(BluredEvent));
        }

        /// <summary>
        /// Событие, вызываемое при анблюринге окна.
        /// </summary>
        public static readonly RoutedEvent UnBluredEvent =
            EventManager.RegisterRoutedEvent("UnBlured", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BluringContainer));
        public event RoutedEventHandler UnBlured
        {
            add { AddHandler(UnBluredEvent, value); }
            remove { RemoveHandler(UnBluredEvent, value); }
        }
        private void OnUnBlured()
        {
            RaiseEvent(new RoutedEventArgs(UnBluredEvent));
        }

        /// <summary>
        /// Событие, вызываемое при изменении состояния меню.
        /// </summary>
        public static readonly RoutedEvent IsBluredChangedEvent =
            EventManager.RegisterRoutedEvent("IsBluredChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BluringContainer));
        public event RoutedEventHandler IsBluredChanged
        {
            add { AddHandler(IsBluredChangedEvent, value); }
            remove { RemoveHandler(IsBluredChangedEvent, value); }
        }
        private void OnIsBluredChangedEvent()
        {
            if (IsBlured)
                OnBlured();
            else
                OnUnBlured();

            RaiseEvent(new RoutedEventArgs(IsBluredChangedEvent));
        }

        #endregion

        #region callbacks

        /// <summary>
        /// Вызывает события, связанные с изменением состояния эффекта.
        /// </summary>
        /// <param name="d">Only HamburgerMenu object</param>
        /// <param name="e"></param>
        private static void OnIsBluredChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BluringContainer container)
            {
                if (container.IsBlured)
                    container.OnBlured();
                else
                    container.OnUnBlured();
            }
        }

        #endregion
    }
}
