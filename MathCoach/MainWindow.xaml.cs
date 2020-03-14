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

        public MainWindow()
        {
            InitializeComponent();
            
            Draw GenerateRandom = new Draw("*");
            ScreenRefresh(GenerateRandom.FirstNumber, GenerateRandom.SecondNumber);
        }


        private void ScreenRefresh(int firstNumber, int secondNumber)
        {
            txtFirstNumber.Text = "" + firstNumber;
            txtSecondtNumber.Text = "" + secondNumber;
            txtResult.Text = "";
        }

        private bool ResultCheck(int firstNumber, int secondNumber, int userResult)
            
        {
            bool _isResultOK;

            int _calculation = firstNumber * secondNumber;
            if (_calculation == userResult)
            {
                _isResultOK = true;
            }
            else
            {
                _isResultOK = false;
            }
            return (_isResultOK);
        }

        #region Handlers

        // on enter push - calculate if results is ok 
        private void OnKeyDownHandler (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int _firstNumber = Convert.ToInt32(txtFirstNumber.Text);
                int _secondNumber = Convert.ToInt32(txtSecondtNumber.Text);
                int _userResult = Convert.ToInt32(txtResult.Text);
                MessageBox.Show("enter key pressed");
                ResultCheck(_firstNumber, _secondNumber, _userResult);
            }
        }

        #endregion

    }
}
