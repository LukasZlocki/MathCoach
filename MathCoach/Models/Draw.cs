using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCoach.Models
{
    public class Draw
    {
        private static string MULTIPLICATION = "*";
        private static string DIVISION = "/";
        private static string ADDITION = "+";
        private static string SUBSTRACTION = "-";

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public string Action { get; set; }
        public int Result { get; set; }
        public int UserResult { get; set; }
        public bool IsUserResultOK { get; set; } 

        private int MinValue = 0;
        private int MaxValue = 10;

        //constr 
        public Draw(string Action)
        {
            this.Action = Action;
            // random 
            Random random = new Random();
            FirstNumber = random.Next(MinValue, MaxValue);
            SecondNumber = random.Next(MinValue, MaxValue);
            Result = CalculateResult(FirstNumber, SecondNumber, Action);
        }


        /// <summary>
        /// Check if result is ok and store bool into class IsResultOK field
        /// </summary>
        /// <param name="UserResult">user result</param>
        /// <returns>bool if result OK is true/false</returns>
        public void ImplementUserResultAndCheckIt(int userResult)
        {
            this.UserResult = userResult;

            if (Result == userResult) 
            { 
                IsUserResultOK = true;
            }
            else
            {
                IsUserResultOK = false;
            }
        }

        /// <summary>
        /// Set up Draw range <-- this is done by user 
        /// </summary>
        /// <param name="minValue">minimum value to describe draw range</param>
        /// <param name="maxValue">maximum value to describe draw range</param>
        public void SetUpDrawRange(int minValue, int maxValue)
        {
            minValue = MinValue;
            maxValue = MaxValue;
        }



        #region Private methods
        private int CalculateResult (int firstNumber, int secondNumber, string action)
        {
            int _result = 0; 
            if(action == MULTIPLICATION) { _result = firstNumber * secondNumber; };
            if(action == DIVISION) { _result = firstNumber / secondNumber; }; 
            if(action == ADDITION) { _result = firstNumber + secondNumber; };
            if(action == SUBSTRACTION) { _result = firstNumber - secondNumber; };
            return (_result);
        }
        #endregion



    }
}
