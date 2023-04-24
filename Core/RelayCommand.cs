using System;
using System.Windows.Input; // Import the ICommand interface and the CommandManager class

namespace AssetsView.Core
{
    // Define a class called RelayCommand that implements the ICommand interface
    class RelayCommand : ICommand
    {
        private Action<object> _execute; // The action to execute when the command is invoked
        private Func<object, bool> _canExecute; // A function that returns whether the command can be executed

        // Define an event that is raised when the CanExecute value of the command changes
        // This event is used by WPF to determine when the command can be executed
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Create a new instance of the RelayCommand class with the given action and canExecute function
        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Check whether the command can be executed with the given parameter
        // If the canExecute function is null, the command can always be executed
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // Execute the command with the given parameter
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
