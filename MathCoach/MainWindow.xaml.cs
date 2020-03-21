using MathCoach.Models;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MathCoach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Draw Task;
        Result UserResults = new Result();

        private static int MAX_SAMPLE = 30;
        private int GlobalSampleCount = 0;

        public MainWindow()
        {
            InitializeComponent();

            TextBoxFocus();

            Task = new Draw("*");
            InitialScreenRefresh(Task.FirstNumber, Task.SecondNumber, Task.Action, UserResults);
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

            GlobalSampleCount++;
            txtTaskCounter.Text = "" + GlobalSampleCount + " / " + MAX_SAMPLE; 

        }

        /// <summary>
        /// Screen refreshement after trigger user action (giving result of calculation)
        /// </summary>
        /// <param name="task">Object with task data</param>
        private void TriggeredScreenRefresh(Draw task, Result userScore)
        {
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
        private void AddScore(bool isGoodResult, ref Result score, ref Draw draw)
        {
            if (isGoodResult == true)
            {
                score.OK = score.OK + 1;
            }
            else
            {
                score.NOK = score.NOK + 1;
            }

            // add draw to list of results
            UserResults.AddDrawResult(draw);

           
        }

        #region Handler on txt box trigered by return press

        // on enter push - calculate if results is ok 
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Task.ImplementUserResultAndCheckIt(Convert.ToInt32(txtResult.Text));

                // adding score to user score
                AddScore(Task.IsUserResultOK, ref UserResults, ref Task);

                if (GlobalSampleCount == 30)
                {
                    ShowWindowWithResults(UserResults);
                }

                // screen refresh
                TriggeredScreenRefresh(Task, UserResults);

                // new task for user
                Task = new Draw("*");
                InitialScreenRefresh(Task.FirstNumber, Task.SecondNumber, Task.Action, UserResults);
            }
        }

        // focus on user txtbox implementing result during window startup
        private void TextBoxFocus()
        {
            txtResult.Focus();
        }

        #endregion


        private void ShowWindowWithResults(Result userResults)
        {
            SummaryWindow sumWin = new SummaryWindow(userResults);
            this.Close();
            sumWin.Show();
        }
    }
}
