using PubSub;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Kitchenator.Wpf.Common
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        readonly Window _owningWindow;
        private RelayCommand _closeCommand;
        private readonly Hub _hub;

        public BaseViewModel(Window owningWindow, Hub hub)
        {
            _hub = hub;
            _owningWindow = owningWindow;
            _closeCommand = new RelayCommand(() => _owningWindow.Close());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected Hub Hub => _hub;

        protected Window ThisWindow => _owningWindow;

        public void Announce(Action setAction, [CallerMemberName] string propertyName = "")
        {
            setAction();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CloseCommand => _closeCommand;
    }
}
