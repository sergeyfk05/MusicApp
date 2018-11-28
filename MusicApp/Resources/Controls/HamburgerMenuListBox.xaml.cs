using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicApp.Resources.Controls
{
    /// <summary>
    /// Логика взаимодействия для HamburgerMenuListBox.xaml
    /// </summary>
    public partial class HamburgerMenuListBox : ListBox
    {
        public HamburgerMenuListBox()
        {
            InitializeComponent();
            RequestedWidth = calcRequestedWidth();
        }


        #region properties

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(HamburgerMenuListBox), new PropertyMetadata((double)72));
                          

        public double ItemIconSize
        {
            get { return (double)GetValue(ItemIconSizeProperty); }
            set { SetValue(ItemIconSizeProperty, value); }
        }
        public static readonly DependencyProperty ItemIconSizeProperty =
            DependencyProperty.Register("ItemIconSize", typeof(double), typeof(HamburgerMenuListBox), new PropertyMetadata((double)36));
                          

        public double ItemTextSize
        {
            get { return (double)GetValue(ItemTextSizeProperty); }
            set { SetValue(ItemTextSizeProperty, value); }
        }
        public static readonly DependencyProperty ItemTextSizeProperty =
            DependencyProperty.Register("ItemTextSize", typeof(double), typeof(HamburgerMenuListBox), new PropertyMetadata((double)24));
               

        public SolidColorBrush ItemBackround
        {
            get { return (SolidColorBrush)GetValue(ItemBackroundProperty); }
            set { SetValue(ItemBackroundProperty, value); }
        }
        public static readonly DependencyProperty ItemBackroundProperty =
            DependencyProperty.Register("ItemBackround", typeof(SolidColorBrush), typeof(HamburgerMenuListBox), new PropertyMetadata(new SolidColorBrush(Colors.Red)));


        public SolidColorBrush SelectedItemBackground
        {
            get { return (SolidColorBrush)GetValue(SelectedItemBackgroundProperty); }
            set { SetValue(SelectedItemBackgroundProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemBackgroundProperty =
            DependencyProperty.Register("SelectedItemBackground", typeof(SolidColorBrush), typeof(HamburgerMenuListBox), new PropertyMetadata(new SolidColorBrush(Colors.Black)));


        public double RequestedWidth
        {
            get { return (double)GetValue(RequestedWidthProperty); }
            set { SetValue(RequestedWidthProperty, value); }
        }
        public static readonly DependencyProperty RequestedWidthProperty =
            DependencyProperty.Register("RequestedWidth", typeof(double), typeof(HamburgerMenuListBox), new PropertyMetadata((double)0));



        #endregion

        private double calcRequestedWidth()
        {
            return 300;
        }
    }
}
