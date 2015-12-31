using System;
using System.Windows.Input;

namespace DecimalConverter.Command
{
    public class DelegateCommand : ICommand
    {

        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute) : this(execute, () => true) { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            this.execute();
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute();
        }

    }
}
