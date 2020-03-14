using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCoach.Models
{
    class Draw
    {
        private static string MULTIPLICATION = "*";
        private static string DIVISION = "/";
        private static string ADDITION = "+";
        private static string SUBSTRACTION = "-";

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public string Action { get; set; }
        public int Result { get; set; }
        public bool IsResultOK { get; set; } 

        private int MinValue = 0;
        private int MaxValue = 10;

        //constr 
        public Draw(string Action)
        {
            Action = this.Action;
            // random 
            Random random = new Random();
            FirstNumber = random.Next(MinValue, MaxValue);
            SecondNumber = random.Next(MinValue, MaxValue);
            Result = CalculateResult(FirstNumber, SecondNumber, Action);
        }

        public bool CheckResult(int UserResult)
        {
            bool _isResultOK = false;
            if (UserResult == Result) 
            { 
                _isResultOK = true;
                IsResultOK = true;
            }
            else
            {
                _isResultOK = false;
                IsResultOK = false;
            }

            return (_isResultOK);
        }

        private int CalculateResult (int firstNumber, int secondNumber, string action)
        {
            int _result = 0; 
            if(action == MULTIPLICATION) { _result = firstNumber * secondNumber; };
            if(action == DIVISION) { _result = firstNumber / secondNumber; }; 
            if(action == ADDITION) { _result = firstNumber + secondNumber; };
            if(action == SUBSTRACTION) { _result = firstNumber - secondNumber; };
            return (_result);
        }


        public void SetUpDrawRange(int minValue, int maxValue)
        {
            minValue = MinValue;
            maxValue = MaxValue;
        }

    }
}
