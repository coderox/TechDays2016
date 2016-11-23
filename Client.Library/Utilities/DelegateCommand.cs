namespace Client.Utilities
{
    using System;
    using System.Windows.Input;

    public class DelegateCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action action, Func<bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null ? this.canExecute.Invoke() : true;
        }

        public void Execute(object parameter)
        {
            if (this.CanExecute(parameter)) {
                this.action.Invoke();
            }
        }
    }
}
