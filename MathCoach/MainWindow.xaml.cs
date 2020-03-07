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
            
            Draw GenerateRandom = new Draw();
            ScreenRefresh(GenerateRandom.FirstNumber, GenerateRandom.SecondNumber);
        }


        private void ScreenRefresh(int firstNumber, int secondNumber)
        {
            txtFirstNumber.Text = "" + firstNumber;
            txtSecondtNumber.Text = "" + secondNumber;
            txtResult.Text = "";
        }


        #region Handlers

        // on enter push - calculate if results is ok 
        private void OnKeyDownHandler (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // ToDo : code checking result here
                MessageBox.Show(" enter key pressed");
            }
        }

        #endregion

    }
}
