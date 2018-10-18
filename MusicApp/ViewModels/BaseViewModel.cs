using MusicApp.Models.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
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

        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                if(value != isOpen)
                {
                    isOpen = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool isOpen;

        private ICommand clickContent;
        public ICommand ClickContent
        {
            get
            {
                if (clickContent == null)
                    clickContent = new RelayCommand(this.ClickContent_Execute, () => IsOpen);

                return clickContent;
            }
        }
        private void ClickContent_Execute()
        {
            IsOpen = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}