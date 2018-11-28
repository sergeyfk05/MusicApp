using System.Windows;

namespace MusicApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
            NavigationMenu.IsOpenChanged += NavigationMenu_IsOpenChanged;
        }

        private void NavigationMenu_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (NavigationMenu.IsOpen)
                OnBlured();
            else
                OnUnBlured();
        }

        #region routed events

        /// <summary>
        /// Событие, вызываемое при блюринге окна.
        /// </summary>
        public static readonly RoutedEvent BluredEvent =
            EventManager.RegisterRoutedEvent("Blured", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));
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
            EventManager.RegisterRoutedEvent("UnBlured", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));
        public event RoutedEventHandler UnBlured
        {
            add { AddHandler(UnBluredEvent, value); }
            remove { RemoveHandler(UnBluredEvent, value); }
        }
        private void OnUnBlured()
        {
            RaiseEvent(new RoutedEventArgs(UnBluredEvent));
        }

        #endregion
    }
}
