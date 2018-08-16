using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicApp.Configs;
using MusicApp.Resources.DataTemplates;
using MusicApp.Views;
using System.Windows.Controls;
using System.Windows;

namespace MusicApp.ViewModels
{
    public sealed class HumburgerMenuViewModel : INotifyPropertyChanged, IViewModel
    {
        public string ActivePageText
        {
            get
            {
                return ((IBaseViewModel)ViewConfig.GetViewInfoByName("Base").ViewModel).ActivePageText;
            }
            set
            {
                if (((IBaseViewModel)ViewConfig.GetViewInfoByName("Base").ViewModel).ActivePageText != value)
                {
                    ((IBaseViewModel)ViewConfig.GetViewInfoByName("Base").ViewModel).ActivePageText = value;
                    OnPropertyChanged("ActivePageText");
                }
            }
        }

        public Resources.DataTemplates.MenuItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
        private Resources.DataTemplates.MenuItem _selectedItem;

        public double HumburgerMenu_OpenPaneLength
        {
            get { return _HumburgerMenu_OpenPaneLength; }
            set
            {
                if (value != _HumburgerMenu_OpenPaneLength)
                {
                    _HumburgerMenu_OpenPaneLength = value;
                    OnPropertyChanged("HumburgerMenu_OpenPaneLength");
                }
            }
        }
        private double _HumburgerMenu_OpenPaneLength = 0;

        public IEnumerable<Resources.DataTemplates.MenuItem> MenuItems
        {
            get { return ViewConfig.GetMenuItems(); }
        }


        public void Loaded_Execute(ListBox menu)
        {
            menu.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            menu.Arrange(new Rect(new Point(0, 0), menu.DesiredSize));
            HumburgerMenu_OpenPaneLength = menu.DesiredSize.Width;
        }


        private ICommand _clickHumburgerButton;
        public ICommand ClickHumburgerButton
        {
            get
            {
                if (_clickHumburgerButton == null)
                { _clickHumburgerButton = new RelayCommand<object>(this.ClickHumburgerButton_Execute); }
                return _clickHumburgerButton;
            }
        }
        private void ClickHumburgerButton_Execute(object parameter)
        {
        }

        private ICommand _activePageChanged;
        public ICommand ActivePageChanged
        {
            get
            {
                if (_activePageChanged == null)
                { _activePageChanged = new RelayCommand<object>(this.ActivePageChanged_Execute); }
                return _activePageChanged;
            }
        }
        private void ActivePageChanged_Execute(object parameter)
        {
            if (parameter is Frame frame)
            {
                ViewInfo info = ViewConfig.GetViewInfoByName(SelectedItem.Name);
                frame.DataContext = info.ViewModel;
                frame.Navigate(info.View);
            }
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
