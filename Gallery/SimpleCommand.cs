using System;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="action">Function to execute when command is called</param>
        /// <param name="canExecute">Function which returns if command can be executed</param>
        public SimpleCommand(Action action, Predicate<object> canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="parameterizedAction">Parameterized function to execute when command is called</param>
        /// <param name="canExecute">Function which returns if command can be executed</param>
        public SimpleCommand(Action<object> parameterizedAction, Predicate<object> canExecute)
        {
            //  Set the action.
            this._parameterizedAction = parameterizedAction;
            this._canExecute = canExecute;
        }

        ///// <summary>
        ///// Gets or sets a value indicating whether this instance can execute.
        ///// </summary>
        ///// <value>
        /////     <c>true</c> if this instance can execute; otherwise, <c>false</c>.
        ///// </value>
        //public bool CanExecute
        //{
        //    get { return canExecute; }
        //    set
        //    {
        //        if (canExecute != value)
        //        {
        //            canExecute = value;
        //            EventHandler canExecuteChanged = CanExecuteChanged;
        //            if (canExecuteChanged != null)
        //                canExecuteChanged(this, EventArgs.Empty);
        //        }
        //    }
        //}

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
            return _canExecute == null ? true : _canExecute(parameter);
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
