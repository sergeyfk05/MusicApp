using MusicApp.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class BaseViewModel : IViewModel, INotifyPropertyChanged, IBaseViewModel
    {
        public BaseViewModel()
        {
            _menuVM = new HamburgerMenuViewModel();
            MenuSource = new MusicApp.Views.HamburgerMenu(_menuVM);
            _menuVM.PropertyChanged += MenuVM_PropertyChanged;
        }

        private void MenuVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "BaseWindowContent_IsBlur":
                    IsBlur = _menuVM.BaseWindowContent_IsBlur;
                    break;
            }
        }

        public bool IsBlur
        {
            get => _isBlur;
            set
            {
                if (_isBlur != value)
                {
                    _isBlur = value;
                    OnPropertyChanged("IsBlur");
                }
            }
        }
        private bool _isBlur;

        public Page MenuSource
        {
            get => _menuSource;
            set
            {
                if (_menuSource != value)
                {
                    _menuSource = value;
                    OnPropertyChanged("MenuSource");
                }
            }
        }
        private Page _menuSource;
        private IMenuViewModel _menuVM;


        private ICommand _clickContent;
        public ICommand ClickContent
        {
            get
            {
                if (_clickContent == null)
                    _clickContent = new RelayCommand<object>(this.ClickContent_Execute);

                return _clickContent;
            }
        }
        private void ClickContent_Execute()
        {
            _menuVM?.CloseMenu();

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}