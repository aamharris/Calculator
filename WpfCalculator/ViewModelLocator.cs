using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCalculator.ViewModels;

namespace WpfCalculator
{
    public class ViewModelLocator
    {
        private static CalculatorViewModel _calculatorViewModel = new CalculatorViewModel(); 

        public static CalculatorViewModel CalculatorViewModel
        {
            get
            {
                return _calculatorViewModel;
            }
        }
    }
}
