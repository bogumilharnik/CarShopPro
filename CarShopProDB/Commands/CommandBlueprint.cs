using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarShopProDB.Commands
{
    /// <summary>
    /// Represents a blueprint for a custom command that implements the ICommand interface.
    /// </summary>
    public class CommandBlueprint : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public event EventHandler? CanExecuteChanged;


        /// <summary>
        /// Initializes a new instance of the CommandBlueprint class with the specified execute action.
        /// </summary>
        /// <param name="execute">The action to be executed when the command is invoked.</param>
        public CommandBlueprint(Action execute) : this(execute, null)
        {
        }

        public CommandBlueprint(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

    }
}
