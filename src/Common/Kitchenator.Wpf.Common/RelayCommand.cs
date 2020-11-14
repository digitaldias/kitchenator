using System;
using System.Windows.Input;

namespace Kitchenator.Wpf.Common
{
    public class RelayCommand : ICommand
    {
        readonly Action             _executeAction;
        readonly Func<object, bool> _canExecuteFunc;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action executeAction, Func<object, bool> canExecuteFunc = null)
        {
            _executeAction  = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _executeAction();
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }
    }
}
