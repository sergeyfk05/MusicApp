using MusicApp.Models.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class BaseViewModel : IViewModel, INotifyPropertyChanged, IBaseViewModel
    {
        public BaseViewModel()
        {
            menuVM = new HamburgerMenuViewModel();
            MenuSource = new MusicApp.Views.HamburgerMenu(menuVM);
            menuVM.PropertyChanged += MenuVM_PropertyChanged;
        }
        private void MenuVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "BaseWindowContent_IsBlur":
                    IsBlur = menuVM.BaseWindowContent_IsBlur;
                    break;
            }
        }

        public bool IsBlur
        {
            get => isBlur;
            set
            {
                if (isBlur != value)
                {
                    isBlur = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool isBlur;

        public Page MenuSource
        {
            get => menuSource;
            set
            {
                if (menuSource != value)
                {
                    menuSource = value;
                    OnPropertyChanged();
                }
            }
        }
        private Page menuSource;
        private IMenuViewModel menuVM;


        private ICommand clickContent;
        public ICommand ClickContent
        {
            get
            {
                if (clickContent == null)
                    clickContent = new RelayCommand(this.ClickContent_Execute/*, () => menuVM != null ? menuVM.Menu_IsOpen : false*/);

                return clickContent;
            }
        }
        private void ClickContent_Execute()
        {
            menuVM?.CloseMenu.Execute(null);

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}