using MathCoach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MathCoach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Draw Task;
        Result UserScore = new Result();

        public MainWindow()
        {
            InitializeComponent();
            
            Task = new Draw("*");
            InitialScreenRefresh(Task.FirstNumber, Task.SecondNumber, Task.Action, UserScore);
        }


        #region Screen refresh

        /// <summary>
        /// initial screen refreshment - initial view for user
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <param name="action">sign like multiple, addition, etc</param>
        private void InitialScreenRefresh(int firstNumber, int secondNumber, string action, Result userScore)
        {
            txtFirstNumber.Text = "" + firstNumber;
            txtSecondNumber.Text = "" + secondNumber;
            txtMathOperation.Text = action;
            txtResult.Text = "";
            txtIsOK.Text = "";

            txtResultOK.Text = "" + userScore.OK;
            txtResultNOK.Text = "" + userScore.NOK;
            
        }

        /// <summary>
        /// Screen refreshement after trigger user action (giving result of calculation)
        /// </summary>
        /// <param name="task">Object with task data</param>
        private void TriggeredScreenRefresh(Draw task, Result userScore)
        {
            // cheking user result
            txtFirstNumber.Text = "" + task.FirstNumber;
            txtSecondNumber.Text = "" + task.SecondNumber;
            txtMathOperation.Text = ""+task.Action;
            txtResult.Text = ""+task.UserResult;
            if (task.IsUserResultOK == true)
            {
                txtIsOK.Background = Brushes.Green;
                txtIsOK.Text = "OK";
            }
            else
            {
                txtIsOK.Background = Brushes.Red;
                txtIsOK.Text = "NOK";
            }

            txtResultOK.Text = "" + userScore.OK;
            txtResultNOK.Text = "" + userScore.NOK;        
        }

        #endregion


        /// <summary>
        /// Wait for 3 seconds
        /// </summary>
        private void Wait()
        {
            System.Threading.Thread.Sleep(3000);
        }

        /// <summary>
        /// Adding user score
        /// </summary>
        /// <param name="isGoodResult">bool is user result is good</param>
        /// <param name="score">reference to object user score </param>
        private void AddScore(bool isGoodResult, ref Result score)
        {
            if (isGoodResult == true)
            {
                score.OK = score.OK + 1;
            }
            else
            {
                score.NOK = score.NOK + 1;
            }
        }

        #region Handler on txt box trigered by return press

        // on enter push - calculate if results is ok 
        private void OnKeyDownHandler (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Task.ImplementUserResultAndCheckIt(Convert.ToInt32(txtResult.Text));

                // adding score to user score
                AddScore(Task.IsUserResultOK, ref UserScore);

                TriggeredScreenRefresh(Task, UserScore);                  
                Task = new Draw("*");
                InitialScreenRefresh(Task.FirstNumber, Task.SecondNumber, Task.Action, UserScore);             
            }
        }

        #endregion

    }
}
