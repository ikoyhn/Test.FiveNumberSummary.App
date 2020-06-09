using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace FiveNumberSummary
{
    public class CalculateCommandDef : ICommand
    {
        private MainViewModel _mainVM;

        public CalculateCommandDef(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_mainVM.Input))
                return false;

            var regex = new Regex(@"[0-9]+(\.[0-9][0-9]?)?");
            var match = regex.IsMatch(_mainVM.Input);
            return match;
        }

        public void Execute(object parameter)
        {
            _mainVM.Calculate();
        }
    }
}
