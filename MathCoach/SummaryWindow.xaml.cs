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
using System.Windows.Shapes;

namespace MathCoach
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {

        public SummaryWindow(Result UserResult)
        {
            InitializeComponent();
            ShowSummaryResult(UserResult);
        }

        private void ShowSummaryResult(Result UserResult)
        {
            string SummaryResults = "";
            string GeneralResults = "Wynik OK : " + UserResult.OK + " \n" + "Wynik NOK : " + UserResult.NOK + " \n\n";
            GatherResults(UserResult,ref SummaryResults);
            ShowAllResults(GeneralResults, SummaryResults);
        }


        private void GatherResults(Result userResult, ref string SummaryResult)
        {
            foreach (var result in userResult.DrawList)
            {
                if (result.IsUserResultOK == true)
                {
                    SummaryResult = SummaryResult + result.FirstNumber + " " + result.Action + " " + result.SecondNumber + " = " + result.Result + " OK" + "\n";
                }
                else
                {
                    SummaryResult = SummaryResult + result.FirstNumber + " " + result.Action + " " + result.SecondNumber + " = " + result.Result + " NOK --> Twoj wynik : " + result.UserResult + "\n";
                }
                
            }
        }

        private void ShowAllResults(string generalResults, string summaryResults)
        {
            TxtToShow.Text = generalResults + summaryResults;
        }


      


    }
}

