using MusicApp.Configs;
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
using System.Windows.Shapes;

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
            this.DataContext = ViewConfig.GetViewInfoByName("Base").ViewModel;
            this.MenuFrame.DataContext = ViewConfig.GetViewInfoByName("Menu").ViewModel;
            this.MenuFrame.Navigate(new Uri("Views/HamburgerMenu.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
