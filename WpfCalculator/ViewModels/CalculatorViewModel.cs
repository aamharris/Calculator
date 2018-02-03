using System;
using System.Windows.Input;
using WpfCalculator.Enums;
using WpfCalculator.Models;
using WpfCalculator.Utility;

namespace WpfCalculator.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        private Calculator _calculator;       

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            NumericInputCommand = new RelayCommand(BuildNumericInput, (param) => true);
            AllClearCommand = new RelayCommand(ClearAll, (param) => true);
            SetOperationCommand = new RelayCommand(SetOperation, (param) => true);
            CalculateCommand = new RelayCommand(PerformCalculation, (param) => true);

        }

        public string CalculatorDisplay
        {
            get
            {
                return _calculator.Display; 
            }
            set
            {
                RaisePropertyChanged("CalculatorDisplay"); 
            }
        }

        public ICommand SetOperationCommand { get; set; }
        public ICommand NumericInputCommand { get; set; }
        public ICommand AllClearCommand { get; set; }
        public ICommand CalculateCommand { get; set; }


        public void ClearAll(object val)
        {
            _calculator.ResetCalculator();
            CalculatorDisplay = _calculator.Display;
        }      

        public void BuildNumericInput(object val)
        {            
            var input = val.ToString();
            _calculator.SetValue(input);
            CalculatorDisplay = _calculator.Display;                           
        }

        public void SetOperation(object op)
        {
            if (_calculator.Value2 != null)
            {
                _calculator.Calculate();
                CalculatorDisplay = _calculator.Display;
            }

            var operation = (OperationType)Enum.Parse(typeof(OperationType), op.ToString()); 
            _calculator.Operation = operation;

            if (_calculator.Result != null)
            {
                _calculator.Value1 = (decimal)_calculator.Result;
                _calculator.Value2 = null; 
                _calculator.Result = null; 
            }                               
        }

        public void PerformCalculation(object obj)
        {
            if (_calculator.Operation != OperationType.None)
            {
                //user is going to repeat calc on new result
                if (_calculator.Result != null)
                {
                    _calculator.Value1 = (decimal)_calculator.Result;
                    _calculator.Result = null;
                }

                _calculator.Calculate();
                CalculatorDisplay = _calculator.Display;
            }
        }
    }
}
