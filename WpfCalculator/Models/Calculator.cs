using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCalculator.Enums;

namespace WpfCalculator.Models
{
    public class Calculator
    {
        public string Display { get; set; }
        public decimal Value1 { get; set; }
        public decimal? Value2 { get; set; }
        public decimal? Result { get; set; }
        public OperationType Operation { get; set; }

        public Calculator()
        {
            ResetCalculator();
        }

        public void ResetCalculator()
        {
            Value1 = 0;
            Value2 = null;
            Result = null;
            Operation = OperationType.None;
            Display = Value1.ToString();
        }

        public void SetValue(string value)
        {            
            if (Value2 != null && Result != null)
            {
                ResetCalculator();
            }
     
            if (this.Operation == OperationType.None)
            {
                //Starting a new operation. Build Value1 
                Value1 = decimal.Parse(String.Concat(Value1, value));
                Display = Value1.ToString();
            }
            else
            {
                //set value for Value 2
                Value2 = decimal.Parse(String.Concat(Value2, value));
                Display = Value2.ToString();
            }
        }

        public void Calculate()
        {
            switch (this.Operation)
            {
                case OperationType.Add:
                    Result = Value1 + Value2;                    
                    break;
                case OperationType.Subtract:
                    Result = Value1 - Value2;                   
                    break;
                case OperationType.Multiply:
                    Result = Value1 * Value2;
                    break;
                case OperationType.Divide:
                    Result = Value1 / Value2;             
                    break;
                default:
                    break;
            }
                        
            if (Result != null)
            {
                Display = ((decimal)Result).ToString("G29");
            }
        }
    }
}
