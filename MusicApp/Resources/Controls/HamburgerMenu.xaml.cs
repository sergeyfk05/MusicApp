using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для HamburgerMenu.xaml
    /// </summary>
    public partial class HamburgerMenu : UserControl, INotifyPropertyChanged
    {
        public HamburgerMenu()
        {
            InitializeComponent();
        }

        #region Main properties

        public double ClosedWidth
        {
            get { return (double)GetValue(ClosedWidthProperty); }
            set { SetValue(ClosedWidthProperty, value); }
        }
        public static readonly DependencyProperty ClosedWidthProperty =
            DependencyProperty.Register("ClosedWidth", typeof(double), typeof(HamburgerMenu), new PropertyMetadata((double)72));

        public double MaxOpenWidth
        {
            get { return (double)GetValue(MaxOpenWidthProperty); }
            set { SetValue(MaxOpenWidthProperty, value); }
        }
        public static readonly DependencyProperty MaxOpenWidthProperty =
            DependencyProperty.Register("MaxOpenWidth", typeof(double), typeof(HamburgerMenu), new PropertyMetadata((double)300));

        public SolidColorBrush Background
        {
            get { return (SolidColorBrush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(SolidColorBrush), typeof(HamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));
       
        #endregion

        #region TopPanel properties

        public SolidColorBrush ToggleButtonColor
        {
            get { return (SolidColorBrush)GetValue(ToggleButtonColorProperty); }
            set { SetValue(ToggleButtonColorProperty, value); }
        }
        public static readonly DependencyProperty ToggleButtonColorProperty =
            DependencyProperty.Register("ToggleButtonColor", typeof(SolidColorBrush), typeof(HamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public SolidColorBrush TopPanelBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(TopPanelBackgroundColorProperty); }
            set { SetValue(TopPanelBackgroundColorProperty, value); }
        }
        public static readonly DependencyProperty TopPanelBackgroundColorProperty =
            DependencyProperty.Register("TopPanelBackgroundColor", typeof(SolidColorBrush), typeof(HamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public double TopPanelHeight
        {
            get { return (double)GetValue(TopPanelHeightProperty); }
            set { SetValue(TopPanelHeightProperty, value); }
        }
        public static readonly DependencyProperty TopPanelHeightProperty =
            DependencyProperty.Register("TopPanelHeight", typeof(double), typeof(HamburgerMenu), new PropertyMetadata((double)60));

        #endregion    


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
