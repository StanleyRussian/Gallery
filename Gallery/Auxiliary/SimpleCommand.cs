﻿using System;
using System.Windows.Input;

namespace Gallery
{
    /// <summary>
    /// The ViewModelCommand class - an ICommand that can fire a function.
    /// </summary>
    public class SimpleCommand : ICommand
    {

        protected Action _action = null;
        protected Action<object> _parameterizedAction = null;

        private Predicate<object> _canExecute;

        private bool canExecute = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="action">Function to execute when command is called</param>
        public SimpleCommand(Action<object> action)
        {
            _parameterizedAction = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="action">Function to execute when command is called</param>
        public SimpleCommand(Action action)
        {
            _action = action;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="action">Function to execute when command is called</param>
        /// <param name="canExecute">Function which returns if command can be executed</param>
        public SimpleCommand(Action action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="parameterizedAction">Parameterized function to execute when command is called</param>
        /// <param name="canExecute">Function which returns if command can be executed</param>
        public SimpleCommand(Action<object> parameterizedAction, Predicate<object> canExecute)
        {
            _parameterizedAction = parameterizedAction;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.
        ///  If the command does not require data to be passed,
        ///  this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        bool ICommand.CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            else
            {
                if (canExecute != _canExecute(parameter))
                {
                    canExecute = _canExecute(parameter);
                    if (CanExecuteChanged != null)
                        CanExecuteChanged(this, EventArgs.Empty);
                }
                return canExecute;
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.
        ///  If the command does not require data to be passed,
        ///  this object can be set to null.</param>
        void ICommand.Execute(object parameter)
        {
            if (_action != null)
                _action();
            else if (_parameterizedAction != null)
                _parameterizedAction(parameter);
        }

        /// <summary>
        /// Occurs when can execute is changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}
