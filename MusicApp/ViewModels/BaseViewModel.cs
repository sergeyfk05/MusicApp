using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;
using MusicApp.Configs;
using MusicApp.Models;

namespace MusicApp.ViewModels
{
    internal class BaseViewModel : IViewModel, INotifyPropertyChanged, IBaseViewModel
    {
        public bool IsBlur
        {
            get { return _isBlur; }
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
            if(ViewConfig.GetViewInfoByName("Menu").ViewModel is HamburgerMenuViewModel menuVM)
                menuVM.CloseHamburgerMenu();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}