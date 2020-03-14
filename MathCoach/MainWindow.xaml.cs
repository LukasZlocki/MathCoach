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

namespace MathCoach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Draw Task;

        public MainWindow()
        {
            InitializeComponent();
            
            Task = new Draw("*");
            InitialScreenRefresh(Task.FirstNumber, Task.SecondNumber, Task.Action);
        }

        /// <summary>
        /// initial screen refreshment - initial view for user
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <param name="action">sign like multiple, addition, etc</param>
        private void InitialScreenRefresh(int firstNumber, int secondNumber, string action)
        {
            txtFirstNumber.Text = "" + firstNumber;
            txtSecondNumber.Text = "" + secondNumber;
            txtMathOperation.Text = action;
            txtResult.Text = "";
            txtIsOK.Text = "";
        }

        /// <summary>
        /// Screen refreshement after trigger user action (giving result of calculation)
        /// </summary>
        /// <param name="task">Object with task data</param>
        private void TriggeredScreenRefresh(Draw task)
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
                
        }
   
        #region Handler on txt box trigered by return press

        // on enter push - calculate if results is ok 
        private void OnKeyDownHandler (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Task.ImplementUserResultAndCheckIt(Convert.ToInt32(txtResult.Text));
                //MessageBox.Show("enter key pressed to implement the result");
                TriggeredScreenRefresh(Task);
            }
        }

        #endregion

    }
}
