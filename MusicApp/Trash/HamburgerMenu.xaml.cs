using MusicApp.Configs;
using MusicApp.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicApp.Views
{
    /// <summary>
    /// Логика взаимодействия для HumburgerMenu.xaml
    /// </summary>
    public partial class HamburgerMenu : Page
    {
        internal HamburgerMenu(IMenuViewModel VM)
        {
            this.DataContext = VM;
            InitializeComponent();
        }
    }
}
