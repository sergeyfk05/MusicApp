using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicApp.Models;

namespace MusicApp.Resources.Controls
{
    /// <summary>
    /// Логика взаимодействия для HamburgerMenuListBox.xaml
    /// </summary>
    public partial class HamburgerMenuListBox : System.Windows.Controls.ListBox
    {
        public HamburgerMenuListBox()
        {
            InitializeComponent();
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




        //public MenuItem SelectedItem
        //{
        //    get { return (MenuItem)GetValue(SelectedItemProperty); }
        //    set { SetValue(SelectedItemProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedItemProperty =
        //    DependencyProperty.Register("SelectedItem", typeof(MenuItem), typeof(HamburgerMenuListBox), new PropertyMetadata(null));



        #endregion

    }
}
